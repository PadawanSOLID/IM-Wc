using ChatWPF.Repositories;
using Entities;

namespace DbTest
{
     class Program
    {
        static void Main(string[] args)
        {
            using (ChatDbContext ctx=new())
            {
                User userA = new()
                {
                    Name = "Solid",
                    Password = "123456"
                };
                User userB = new()
                {
                    Name = "HeiHei",
                    Password = "123456"
                };
                User userC = new()
                {
                    Name = "JCC",
                    Password = "123456"
                };
                User userD = new()
                {
                    Name = "Noisy Robot",
                    Password = "123456"
                };
                User userE = new()
                {
                    Name = "Vincent",
                    Password = "123456"
                };
                ctx.Users.Add(userA);
                ctx.Users.Add(userB);
                ctx.Users.Add(userC);
                ctx.Users.Add(userD);
                ctx.Users.Add(userE);
                ctx.SaveChanges();
            }
        }
    }
}
