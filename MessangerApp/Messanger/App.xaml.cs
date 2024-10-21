using ApplicationData.Core.Context;
using Messanger.Settings;
using Messanger.Settings.Utilities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Messanger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var path = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            var useOtherDb = ConfigurationManager.AppSettings["UseOtherDb"];
            if (!string.IsNullOrEmpty(path) && useOtherDb!.ToLower()=="true") 
            { 
                AppDbContext.SetSqliteConnect(path);
            }
            else
                AppDbContext.SetSqliteConnect();
            try
            {
                new DatabaseFacade(new AppDbContext()).EnsureCreated();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            ThemeConfigurator.LoadTheme();
        }
    }

}
