using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using Messanger.Settings;
using Messanger.Settings.Utilities;
using Messanger.Utilities;
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
        #region Feilds & Properties
        private string login = string.Empty; 
        private string password = string.Empty;
        public string Login { get => login; set => Set(ref login, value, nameof(Login)); }
        public string Password { get => password; set => Set(ref password, value, nameof(Password)); }
        #endregion

        #region Commands
        public RelayCommand ChangeThemeCommand { get; } = new(o => 
        {
            ThemeConfigurator.ChangeTheme();
        });
        public RelayCommand LoginCommand { get; } = new(o =>
        {
            
        });
        public RelayCommand RegisterCommand { get; } = new(o =>
        {
            
        });
        #endregion
    }
}