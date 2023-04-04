using Microsoft.AspNetCore.Mvc;
using PizzaShop.WebUI.Models;
using PizzaShop.Domain.Interfaces;
using System.Security.Claims;

namespace PizzaShop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;


        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            await _identityService.AuthorizeAsync(model.Username, model.Password);

            return View(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            await _identityService.CreateUserAsync(model.Username, model.Password, model.ConfirmPassword);

            return View(model.ReturnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _identityService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
