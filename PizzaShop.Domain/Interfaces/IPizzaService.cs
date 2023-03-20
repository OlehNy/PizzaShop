using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;

namespace PizzaShop.Domain.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetPizzas();
        IEnumerable<Pizza> GetPizzasByCategory(Category category);
        Task CreatePizzaAsync(Pizza pizza);
        Task DeletePizzaAsync(int id);
        Task UpdatePizzaAsync(Pizza pizza);
    }
}
