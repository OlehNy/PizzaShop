using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Domain.Services;
using PizzaShop.Domain.Interfaces;

namespace PizzaShop.Domain
{
    public static class RegistrationExtensions
    {
        public static void AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPizzaService, PizzaService>();
            serviceCollection.AddScoped<IIngredientService, IngredientService>();
        }
    }
}
