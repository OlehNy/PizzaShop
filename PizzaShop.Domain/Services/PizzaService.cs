﻿using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using Microsoft.EntityFrameworkCore;

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
            => _dbContext.Pizzas
            .Include(pizza => pizza.PizzaIngredients)
                .ThenInclude(pz => pz.Ingredient);

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

        public IEnumerable<Pizza> GetPizzasByCategory(Category? category)
        {
            var pizzas = _dbContext.Pizzas;
            var filtredPizzas = pizzas.Where(pizza => pizza.Category == category);
            return filtredPizzas;
        }

        public async Task AddIngredientToPizza(CustomPizza pizza, Ingredient ingredient)
        {
            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            await _dbContext.PizzaIngredients.AddAsync(new PizzaIngredient()
            {
                IngredientId = ingredient.Id,
                PizzaId = pizza.Id
            });
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task AddIngredientToPizza(CustomPizza pizza, IEnumerable<Ingredient> ingredients)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            if (_dbContext.CustomPizzas.Find(pizza.Id) == null)
            {
                await _dbContext.CustomPizzas.AddAsync(pizza);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }

            List<PizzaIngredient> pizzaIngredients = new List<PizzaIngredient>();
            foreach (var item in ingredients)
            {
                pizzaIngredients.Add(new PizzaIngredient()
                {
                    IngredientId = item.Id,
                    PizzaId = pizza.Id
                });
            }
            await _dbContext.PizzaIngredients.AddRangeAsync(pizzaIngredients);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Pizza> GetPizzaByIdAsync(int id)
        {
            var pizza = await _dbContext.Pizzas.FindAsync(id);

            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza));
            }

            return pizza;
        }

        public async Task<IReadOnlyList<Pizza>> GetTopThreePizzas()
        {
            var pizzaSales = _dbContext.OrderItems.GroupBy(oi => oi.Pizza)
                                       .Select(g => new { PizzaObj = g.Key, SalesCount = g.Sum(oi => oi.Quantity) })
                                       .OrderByDescending(p => p.SalesCount)
                                       .Take(3);

            return await pizzaSales.Select(p => p.PizzaObj).OfType<Pizza>().ToListAsync();
        }
    }
}
