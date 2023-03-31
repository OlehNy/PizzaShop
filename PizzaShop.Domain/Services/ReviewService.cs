using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Interfaces;

namespace PizzaShop.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IAppDbContext _dbContext;

        public ReviewService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateReviewAsync(string comment, string userId)
        {
            var review = new Review()
            {
                UserId = userId,
                Comment = comment,
                ReviewData = new DataTimeService().Now
            };

            await _dbContext.Reviews.AddAsync(review);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public IEnumerable<Review> GetReviews()
            => _dbContext.Reviews;
    }
}
