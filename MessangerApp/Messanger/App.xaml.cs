using ApplicationData.Core.Context;
using Messanger.Settings;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using System.Windows;
using System.Windows.Controls.Primitives;

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
