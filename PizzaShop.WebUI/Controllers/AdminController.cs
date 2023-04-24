using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Enum;
using PizzaShop.WebUI.Hubs;
using PizzaShop.Domain.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace PizzaShop.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IHubContext<OrderHub> _hubContext;
        public AdminController(IAdminService adminService,
            IHubContext<OrderHub> hubContext)
        {
            _adminService = adminService;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var orders = _adminService.GetUnfinishedOrders();

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var order = await _adminService.ChangeOrderStatus(orderId, orderStatus);

            var userId = order.UserId; 

            await _hubContext.Clients.User(userId).SendAsync("Receive", orderStatus.ToString());

            return new EmptyResult(); 
        }
    }
}
