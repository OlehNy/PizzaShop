using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PizzaShop.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
