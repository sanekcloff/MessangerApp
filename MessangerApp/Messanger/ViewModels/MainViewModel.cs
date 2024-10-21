using ApplicationData.Models;
using Messanger.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(User currentUser)
        {
            this.CurrentUser = currentUser;
        }
        #region Fields & Properties
        private User currentUser;

        public User CurrentUser { get => currentUser; set => Set(ref currentUser, value, nameof(CurrentUser)); }
        #endregion
    }
}
