using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Interfaces;

namespace PizzaShop.Domain.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IAppDbContext _dbContext;

        public IngredientService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteIngredientAsync(int id)
        {
            var ingredient = await _dbContext.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            _dbContext.Ingredients.Remove(ingredient);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public IEnumerable<Ingredient> GetIngredients()
            => _dbContext.Ingredients;

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            _dbContext.Ingredients.Update(ingredient);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
