using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;

namespace PizzaShop.Domain.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderItemAsync(string userId, BasePizza pizza, int quantity);
        Task<Order> PayOrder(int id, string shippingAddress);
        IEnumerable<Order> GetAllOrders(string userId);
        Task DeleteOrderAsync(int id);
        Task DeleteOrderItemFromOrder(int orderId, int id);
    }
}
