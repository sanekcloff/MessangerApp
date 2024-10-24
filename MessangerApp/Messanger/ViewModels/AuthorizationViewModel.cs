using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using Messanger.Settings;
using Messanger.Settings.Utilities;
using Messanger.Utilities;
using Messanger.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Messanger.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        public AuthorizationViewModel(Window window, AppDbContext context)
        {
            // Properties
            currentWindow = window;
            this.context = context;
            email = "test";
            password = "test";

            // Commands
            ChangeThemeCommand = new(o =>
            {
                ThemeConfigurator.ChangeTheme();
            });
            RegisterCommand = new(o =>
            {
                new RegistrationView(context).ShowDialog();
            });
            LoginCommand = new(o => 
            {
                new MainView(UserService.Login(email, password, context), context).Show();
                currentWindow.Close();
            });
        }
        #region Feilds & Properties
        private AppDbContext context;
        private Window currentWindow;
        private string email;
        private string password;
        public string Email { get => email; set => Set(ref email, value, nameof(Email)); }
        public string Password { get => password; set => Set(ref password, value, nameof(Password)); }
        #endregion

        #region Commands
        public RelayCommand ChangeThemeCommand { get; } 
        public RelayCommand LoginCommand { get; } 
        public RelayCommand RegisterCommand { get; } 
        #endregion


    }
}