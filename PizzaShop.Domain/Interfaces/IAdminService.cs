﻿using PizzaShop.Domain.Enum;
using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Interfaces
{
    public interface IAdminService
    {
        Task<Order> ChangeOrderStatus(int orderId, OrderStatus orderStatus);
        IEnumerable<Order> GetUnfinishedOrders();
    }
}
