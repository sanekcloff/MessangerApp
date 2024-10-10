using ApplicationData.Core.Context;
using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext ctx = new())
            {
                ctx.Statuses.Add(new Status() 
                { 
                    IsBusy = false, 
                    IsDeleted = false, 
                    IsMovedAway = false, 
                    Title = "В сети"
                });
                ctx.SaveChanges();
                ctx.Statuses.ForEachAsync((status) =>
                {
                    Console.WriteLine(status.Title);
                });
            }
        }
    }
}
