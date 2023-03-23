namespace PizzaShop.Domain.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> AuthorizeAsync(string userName, string password);
        Task<string> CreateUserAsync(string userName, string password, string confirmPassword);
        Task Logout();
    }
}
