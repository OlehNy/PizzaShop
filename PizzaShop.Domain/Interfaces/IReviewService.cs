using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Interfaces
{
    public interface IReviewService
    {
        Task CreateReviewAsync(string comment, string userId);
        IEnumerable<Review> GetReviews();
    }
}
