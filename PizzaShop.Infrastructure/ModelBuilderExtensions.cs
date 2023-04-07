using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using PizzaShop.Infrastructure.Identity;

namespace PizzaShop.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Pizza>()
                .HasData(
                    new Pizza()
                    {
                        Id = 1,
                        Name = "Pizza #1",
                        ImageUrl = "https://i.imgur.com/Uc8avMV.jpeg",
                        Price = 100,
                        Category = Category.Meat
                    },
                    new Pizza()
                    {
                        Id = 2,
                        Name = "Pizza #2",
                        ImageUrl = "https://i.imgur.com/mH8v2Oj.jpeg",
                        Price = 110,
                        Category = Category.Seafood
                    },
                    new Pizza()
                    {
                        Id = 3,
                        Name = "Pizza #3",
                        ImageUrl = "https://i.imgur.com/aiv72w8.jpeg",
                        Price = 125,
                        Category = Category.Vegetable
                    });

            builder.Entity<Ingredient>()
                .HasData(
                new Ingredient()
                {
                    Id = 1,
                    Name = "Cheese",
                },
                new Ingredient()
                {
                    Id = 2,
                    Name = "Mushroom"
                },
                new Ingredient()
                {
                    Id = 3,
                    Name = "Sausage"
                },
                new Ingredient()
                {
                    Id = 4,
                    Name = "Peppers"
                },
                new Ingredient()
                {
                    Id = 5,
                    Name = "Olives"
                },
                new Ingredient()
                {
                    Id = 6,
                    Name = "Tuna"
                });

            builder.Entity<PizzaIngredient>()
                .HasData(
                new PizzaIngredient()
                {
                    PizzaId = 1,
                    IngredientId = 1
                },
                new PizzaIngredient()
                {
                    PizzaId = 1,
                    IngredientId = 2
                },
                new PizzaIngredient()
                {
                    PizzaId = 1,
                    IngredientId = 3
                },
                new PizzaIngredient()
                {
                    PizzaId = 3,
                    IngredientId = 4
                },
                new PizzaIngredient()
                {
                    PizzaId = 3,
                    IngredientId = 2
                },
                new PizzaIngredient()
                {
                    PizzaId = 3,
                    IngredientId = 5
                },
                new PizzaIngredient()
                {
                    PizzaId = 3,
                    IngredientId = 1
                },
                new PizzaIngredient()
                {
                    PizzaId = 2,
                    IngredientId = 1
                },
                new PizzaIngredient()
                {
                    PizzaId = 2,
                    IngredientId = 6
                });
        }
    }
}
