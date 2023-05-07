using PizzaShop.Domain.Entities;

namespace PizzaShop.Domain.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();
        Task CreateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(int id);
        Task UpdateIngredientAsync(Ingredient ingredient);
        IEnumerable<Ingredient> GetIngredientsByNames(List<string> names);
    }
}
