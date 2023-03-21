namespace PizzaShop.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<PizzaIngredient>? PizzaIngredients { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
