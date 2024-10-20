using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using Messanger.Settings;
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
        #region Commands
        public RelayCommand ChangeThemeCommand { get; } = new(o => 
        {

        }); 
        #endregion
    }
}