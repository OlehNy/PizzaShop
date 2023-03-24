using PizzaShop.Domain.Interfaces;

namespace PizzaShop.Domain.Services
{
    public class DataTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
