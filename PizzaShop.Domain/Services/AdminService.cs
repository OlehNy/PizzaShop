using PizzaShop.Domain.Enum;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Domain.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAppDbContext _dbContext;

        public AdminService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Order> GetUnfinishedOrders()
        {
            var orders = _dbContext.Orders
                .Where(order => order.OrderStatus != OrderStatus.Delivered)
				.Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Pizza);

            return orders;
        }
        public async Task<Order> ChangeOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.OrderStatus = orderStatus;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return order;
        }
    }
}
