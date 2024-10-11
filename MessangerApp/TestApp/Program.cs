using ApplicationData.Core.Context;
using ApplicationData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseFacade facade = new DatabaseFacade(new AppDbContext());
            facade.EnsureCreated();
        }

    }
}
