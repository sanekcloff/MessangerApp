using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace ApplicationData.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        static AppDbContext() 
        {
            DatabaseFacade database = new(new AppDbContext());
            database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent;
            var connectionString = $@"Data Source={dir}\ApplicationData\Core\Database\MessangerDB.db";

            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }


        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
