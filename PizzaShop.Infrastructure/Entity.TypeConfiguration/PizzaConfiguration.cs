using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Infrastructure.Entity.TypeConfiguration
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(pizza => pizza.Id);
            builder.HasIndex(pizza => pizza.Id).IsUnique();
            builder.Property(pizza => pizza.Name).HasMaxLength(50);
            builder.Property(pizza => pizza.Description).HasMaxLength(500);

        }
    }
}
