namespace PizzaShop.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int PizzaId { get; set; }
        public virtual BasePizza? Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
