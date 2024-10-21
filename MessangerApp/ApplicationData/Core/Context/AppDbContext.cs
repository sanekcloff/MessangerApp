using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.IO;

namespace ApplicationData.Core.Context
{
    public class AppDbContext : DbContext
    {
        private static string connectionString = string.Empty; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
        public static void SetSqliteConnect()
        {
            var dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent;
            connectionString = $@"Data source={dir}\ApplicationData\Core\Database\MessangerDB.db";
        }
        public static void SetSqliteConnect(string path)
        {
            connectionString = path.Insert(0,"Data source = ");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
