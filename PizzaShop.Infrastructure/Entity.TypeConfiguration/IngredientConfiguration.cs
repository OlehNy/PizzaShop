using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Infrastructure.Entity.TypeConfiguration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(ingredient => ingredient.Id);
            builder.Property(ingredient => ingredient.Name).HasMaxLength(50);
        }
    }
}
