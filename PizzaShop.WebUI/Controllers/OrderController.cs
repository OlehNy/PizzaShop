using Microsoft.AspNetCore.Mvc;

namespace PizzaShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
