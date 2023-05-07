using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Domain.Entities
{
    public class BasePizza
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Custom";
        public decimal Price { get; set; }
        public ICollection<PizzaIngredient>? PizzaIngredients { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
