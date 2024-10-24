using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using ApplicationData.Utilities.Converters;
using Messanger.Utilities;
using Messanger.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Messanger.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(User currentUser, Window window, AppDbContext context)
        {
            this.currentUser = currentUser;
            this.context = context;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateContext;
            timer.Start();
        }

        #region Fields & Properties
        private Window window;
        private AppDbContext context;
        private User currentUser;

        public User CurrentUser { get => currentUser; set => Set(ref currentUser, value, nameof(CurrentUser)); }
        #endregion

        #region Methods
        internal async void UpdateContext(object? sender, EventArgs e)
        {
            currentUser.LastActive = DateTime.Now;
            await context.SaveChangesAsync();
        }
        internal void CloseApp()
        {
            UserService.UserExit(currentUser, context);
            Application.Current.Shutdown();
        }
        #endregion
    }
}
