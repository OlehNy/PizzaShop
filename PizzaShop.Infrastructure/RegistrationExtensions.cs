using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Infrastructure.Identity;
using PizzaShop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PizzaShop.Infrastructure
{
    public static class RegistrationExtensions
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDB"));

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            serviceCollection.AddScoped<IAppDbContext, AppDbContext>();
            serviceCollection.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
