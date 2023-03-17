namespace PizzaShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public string? ShippingAddress { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
