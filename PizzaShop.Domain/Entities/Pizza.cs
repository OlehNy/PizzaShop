using PizzaShop.Domain.Enum;

namespace PizzaShop.Domain.Entities
{
    public class Pizza : BasePizza
    {
        public string? ImageUrl { get; set; }
        public Category Category { get; set; }
    }
}
