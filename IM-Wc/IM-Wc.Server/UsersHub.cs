using Entities;
using Microsoft.AspNetCore.SignalR;

namespace IM_Wc.Server
{
    public class UsersHub:Hub
    {
        public async Task Login(User user) 
        {
            string connectionId = Context.ConnectionId;
            Console.WriteLine(connectionId);
            await Clients.Caller.SendAsync("LoginCallback", new User() { Name = "callback" });
        }
    }
}
