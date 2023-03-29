namespace PizzaShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice
        {
            get { return OrderItems?.Sum(item => item.Quantity * (item.Pizza?.Price ?? 0)) ?? 0; }
        }
        public bool IsPaid { get; set; }
        public string? ShippingAddress { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
