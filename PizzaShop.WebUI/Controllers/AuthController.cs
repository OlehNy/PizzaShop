using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace PizzaShop.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(string returnUrl = "/") =>
            Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl
            });

        public IActionResult Logout()
            => SignOut(CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
    }
}
