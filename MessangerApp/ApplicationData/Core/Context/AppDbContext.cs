using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.IO;

namespace ApplicationData.Core.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(getSqliteConnect());
            optionsBuilder.UseLazyLoadingProxies();
        }

        string getSqliteConnect()
        {
            var dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent;
            return $@"Data Source=\ApplicationData\Core\Database\MessangerDB.db";
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
