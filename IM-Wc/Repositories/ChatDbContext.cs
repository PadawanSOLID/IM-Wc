using ChatWPF.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWPF.Repositories
{
    public class ChatDbContext : DbContext
    {
      public  DbSet<User> Users { get; set; }
      public  DbSet<UserRelationship> UserRelationships { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = "Data Source=SOU24L112300680\\SQLEXPRESS;Initial Catalog=Wc;Integrated Security=True;Encrypt=False";
            //string connStr = "Data Source=LAPTOP-F8JGEQPH;Initial Catalog=Wc;Integrated Security=True;Encrypt=False";
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public User GetUserById(int id)
        {
            var user = Users.Include(u=>u.Contactors).ThenInclude(u=>u.Contactor).FirstOrDefault(n=>n.Id == id);
            //var contactors = user.Contactors.Select(n => n.Contactor).ToList();
            return user;
        }

    }
}
