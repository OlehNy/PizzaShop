namespace PizzaShop.Domain.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> GetUserNameAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userName, string password);
        Task<string> CreateUserAsync(string userName, string password, string confirmPassword);
        Task DeleteUserAsync(string userId);
        Task Logout();
    }
}
