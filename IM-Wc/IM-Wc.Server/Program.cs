
namespace IM_Wc.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR();
 
            var app = builder.Build();
         
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            
            app.MapHub<UsersHub>("/UserHub");
            app.Run();
        }
    }
}
