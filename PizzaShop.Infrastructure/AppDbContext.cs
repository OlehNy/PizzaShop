using Microsoft.EntityFrameworkCore;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Infrastructure.Entity.TypeConfiguration;

namespace PizzaShop.Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDB");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PizzaConfiguration).Assembly);
            builder.Seed();
            base.OnModelCreating(builder);
        }
        
    }
}
