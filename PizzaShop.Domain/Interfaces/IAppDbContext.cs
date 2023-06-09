﻿using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Pizza> Pizzas { get; set; }
        DbSet<CustomPizza> CustomPizzas { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        DbSet<Review> Reviews { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
