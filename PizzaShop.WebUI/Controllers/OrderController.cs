using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PizzaShop.WebUI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IPizzaService _pizzaService;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService service,
            IPizzaService pizzaService)
        {
            _orderService = service;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            return View(_orderService
                .GetAllOrders(UserId.ToString())
                .FirstOrDefault(o => !o.IsPaid));
        }

        public IActionResult OrderHistory()
        {
            return View(_orderService
                .GetAllOrders(UserId.ToString())
                .Where(order => order.IsPaid));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int pizzaId, int quantity)
        {
            var pizza = _pizzaService.GetPizzas().FirstOrDefault(pizza => pizza.Id == pizzaId);
            await _orderService.AddOrderItemAsync(UserId.ToString(), pizza, quantity);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderItem(int orderId, int id)
        {
            await _orderService.DeleteOrderItemFromOrder(orderId, id);

            return RedirectToAction(nameof(Index));
        }
    }
}
