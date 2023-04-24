using Microsoft.AspNetCore.SignalR;

namespace PizzaShop.WebUI.Hubs
{
    public class OrderHub : Hub
    {
        public async Task Send(string message, string user)
        {
            await Clients.User(user).SendAsync("Receive", message);
        }
    }
}
    