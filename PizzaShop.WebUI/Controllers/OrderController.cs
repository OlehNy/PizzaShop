using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using PizzaShop.WebUI.Models;
using System.Security.Claims;

namespace PizzaShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly IOrderService _orderService;
        private Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
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
        public async Task<IActionResult> PayOrder(int id, string shippingAddress)
        {
            await _orderService.PayOrder(id, shippingAddress);

            return RedirectToAction("OrderHistory");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int pizzaId, int quantity)
        {
            var pizza = _pizzaService.GetPizzas().FirstOrDefault(pizza => pizza.Id == pizzaId);
            await _orderService.AddOrderItemAsync(UserId.ToString(), pizza, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);

            return RedirectToAction("Index");
        }
    }
}
