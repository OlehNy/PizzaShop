using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Infrastructure.Entity.TypeConfiguration
{
    public class PizzaIngredientConfiguration 
        : IEntityTypeConfiguration<PizzaIngredient>
    {
        public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
        {
            builder.HasKey(pi => new { pi.PizzaId, pi.IngredientId });

            builder.HasOne(pi => pi.Pizza)
                .WithMany(p => p.PizzaIngredients)
                .HasForeignKey(pi => pi.PizzaId); 

            builder.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.PizzaIngredients)
                .HasForeignKey(pi => pi.IngredientId);
        }
    }
}
