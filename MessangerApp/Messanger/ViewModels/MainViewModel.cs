using ApplicationData.Models;
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

namespace Messanger.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(User currentUser, Window window)
        {
            this.currentUser = currentUser;
            if (currentUser.Image != null)
                (window as MainView)!.UserImage.Fill = new ImageBrush(ImageConverter.GetBitmapImage(currentUser.Image!));
        }
        #region Fields & Properties
        private Window window;
        private User currentUser;

        public User CurrentUser { get => currentUser; set => Set(ref currentUser, value, nameof(CurrentUser)); }
        #endregion
    }
}
