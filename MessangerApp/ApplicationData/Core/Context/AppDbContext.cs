using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApplicationData.Core.Context
{
    public class AppDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(getConnectionString());
            optionsBuilder.UseLazyLoadingProxies();
        }

        static string getConnectionString()
        {
            var dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent;
            return $@"Data Source={dir}\ApplicationData\Core\Database\MessangerDB.db";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
