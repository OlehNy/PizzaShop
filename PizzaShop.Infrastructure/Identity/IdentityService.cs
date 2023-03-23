using Microsoft.AspNetCore.Identity;
using PizzaShop.Domain.Interfaces;

namespace PizzaShop.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> AuthorizeAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            return result.Succeeded;
        }

        public async Task<string> CreateUserAsync(string userName, string password, string confirmPassword)
        {
            var user = new ApplicationUser()
            {
                UserName = userName
            };

            if (password != confirmPassword)
            {
                throw new ArgumentException(nameof(confirmPassword));
            }

            await _userManager.CreateAsync(user, password);


            return user.Id;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
