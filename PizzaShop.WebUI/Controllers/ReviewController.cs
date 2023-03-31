using Microsoft.AspNetCore.Mvc;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using System.Security.Claims;

namespace PizzaShop.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public IActionResult Index()
        {
            var reviews = _reviewService.GetReviews();
            return View(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(string comment)
        {
            await _reviewService.CreateReviewAsync(comment, UserId.ToString());

            return RedirectToAction("OrderHistory", "Order");
        }
    }
}
