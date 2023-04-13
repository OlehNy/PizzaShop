using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Infrastructure
{
    public static class RegistrationExtensions
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDB"));

            serviceCollection.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}
