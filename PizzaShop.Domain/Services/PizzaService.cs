using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;

namespace PizzaShop.Domain.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IAppDbContext _dbContext;

        public PizzaService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pizza> GetPizzas()
            => _dbContext.Pizzas;

        public async Task CreatePizzaAsync(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }

            await _dbContext.Pizzas.AddAsync(pizza);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeletePizzaAsync(int id)
        {
            var pizza = await _dbContext.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }

            _dbContext.Pizzas.Remove(pizza);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdatePizzaAsync(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }

            _dbContext.Pizzas.Update(pizza);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public IEnumerable<Pizza> GetPizzasByCategory(Category category)
        {
            var pizzas = _dbContext.Pizzas;
            var filtredPizzas = pizzas.Where(pizza => pizza.Category == category);
            return filtredPizzas;
        }
    }
}
