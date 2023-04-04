using Microsoft.AspNetCore.Mvc;
using PizzaShop.WebUI.Models;
using System.Diagnostics;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Localization;

namespace PizzaShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaService _pizzaService;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, 
            IPizzaService service,
            IMapper mapper,
            IReviewService reviewService)
        {
            _logger = logger;
            _pizzaService = service;
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var topPizzas = (await _pizzaService.GetTopThreePizzas())
                .Select(pizza => _mapper.Map<TopPizzaViewModel>(pizza));

            var reviews = _reviewService
                .GetReviews()
                .Select(review => _mapper.Map<ReviewViewModel>(review));
            ViewBag.Reviews = reviews;

            return View(topPizzas);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}