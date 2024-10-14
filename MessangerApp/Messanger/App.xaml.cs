using ApplicationData.Core.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Windows;

namespace Messanger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            DatabaseFacade database = new(new AppDbContext());
            database.EnsureCreated();
        }
    }

}
