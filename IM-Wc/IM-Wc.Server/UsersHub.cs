using ChatWPF.Repositories;
using Entities;
using Microsoft.AspNetCore.SignalR;

namespace IM_Wc.Server
{
    public class UsersHub:Hub
    {

        public async Task Login(int id)
        {
            User user = null;
            string connectionId = Context.ConnectionId;
            using (ChatDbContext ctx = new())
            {
                user = ctx.GetUserById(id);
            }
            await Clients.Caller.SendAsync("LoginCallback", user);
        }

        public async Task GetAllUsers() 
        {
            using (ChatDbContext ctx=new())
            {
                var users = ctx.Users.ToList();
                await Clients.Caller.SendAsync("GetAllUsersCallback",users);
            }
        }

    }
}
