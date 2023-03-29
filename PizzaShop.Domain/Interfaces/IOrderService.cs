using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderItemAsync(string userId, Pizza pizza, int quantity);
        Task<Order> PayOrder(int id, string shippingAddress);
        IEnumerable<Order> GetAllOrders(string userId);
        Task DeleteOrderAsync(int id);
        Task DeleteOrderItemFromOrder(int orderId, int id);
    }
}
