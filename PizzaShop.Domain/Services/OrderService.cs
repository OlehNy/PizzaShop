using Microsoft.AspNetCore.Http;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbContext _dbContext;

        public OrderService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrderItemAsync(string userId, Pizza pizza, int quantity)
        {
            if (_dbContext.Orders.Count() == 0 || _dbContext.Orders.Last().IsPaid)
            {
                await _dbContext.Orders.AddAsync(new Order { UserId = userId });
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }

            Order order = _dbContext.Orders.Last(order => !order.IsPaid);

            var orderItem = new OrderItem()
            {
                OrderId = order.Id,
                PizzaId = pizza.Id,
                Quantity = quantity
            };

            if (order.OrderItems == null)
            {
                order.OrderItems = new List<OrderItem>() { orderItem };
            }
            else
            {
                order.OrderItems.Add(orderItem);
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<Order> PayOrder(int id, string shippingAddress)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            order.ShippingAddress = shippingAddress;
            order.OrderDate = new DataTimeService().Now;
            order.IsPaid = true;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return order;
        }

        public IEnumerable<Order> GetAllOrders(string userId)
        {
            var orders = _dbContext.Orders
                .AsQueryable()
                .Where(order => order.UserId == userId)
                .Include(order => order.OrderItems)
                    .ThenInclude(oi => oi.Pizza);

            return orders;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
