namespace PizzaShop.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Pizza? Pizza { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order? Order { get; set; }
    }
}
