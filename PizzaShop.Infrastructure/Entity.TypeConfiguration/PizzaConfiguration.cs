using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Infrastructure.Entity.TypeConfiguration
{
    public class PizzaConfiguration : IEntityTypeConfiguration<BasePizza>
    {
        public void Configure(EntityTypeBuilder<BasePizza> builder)
        {
            builder.HasKey(pizza => pizza.Id);
            builder.Property(pizza => pizza.Name).HasMaxLength(50);
        }
    }
}
