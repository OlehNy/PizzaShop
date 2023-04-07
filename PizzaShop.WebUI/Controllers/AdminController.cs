using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Enum;
using PizzaShop.Domain.Interfaces;

namespace PizzaShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var orders = _adminService.GetUnfinishedOrders();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserOrderStatus(int orderId, OrderStatus orderStatus)
        {
            await _adminService.ChangeOrderStatus(orderId, orderStatus);

            return new EmptyResult();
        }
    }
}
