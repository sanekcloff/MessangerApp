using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using Messanger.Utilities;
using Messanger.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Messanger.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(Window window,AppDbContext context)
        {
            // Fields
            this.context = context;
            openFileDialog = new OpenFileDialog()
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif", // Фильтр для изображений
                Title = "Выберите изображение"
            };
            email = string.Empty;
            nickname = string.Empty;
            password = string.Empty;
            imagePath = string.Empty;
            IsUploaded = false;

            // Commands
            Registration = new(o =>
            {
                UserService.Create(nickname, email,password,imagePath,context);
            });
            Leave = new(o =>
            {
                window.Close();
            });
            UploadImage = new(o =>
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    ImagePath = openFileDialog.FileName;
                    IsUploaded=true;

                    //imagePath = openFileDialog.FileName;
                    //var image = new ImageBrush(new BitmapImage(new Uri(imagePath)));
                    //image.Stretch = Stretch.UniformToFill;
                    //(window as RegistrationView)!.Avatar.Fill = image;
                }
            });
        }
        #region Fields & Properties
        private AppDbContext context;
        private Window window;
        private OpenFileDialog openFileDialog;

        private bool isUploaded;
        private string email;
        private string nickname;
        private string password;
        private string imagePath;

        public bool IsUploaded { get => isUploaded; set => Set(ref isUploaded, value, nameof(IsUploaded)); }
        public string Email { get => email; set => Set(ref email, value, nameof(Email)); }
        public string Password { get => password; set => Set(ref password, value, nameof(Password)); }
        public string Nickname { get => nickname; set => Set(ref nickname, value, nameof(Nickname)); }
        public string ImagePath { get => imagePath; set => Set(ref imagePath, value, nameof(ImagePath)); }
        #endregion

        #region Commands
        public RelayCommand Registration { get; }
        public RelayCommand Leave { get; }
        public RelayCommand UploadImage { get; }
        #endregion
    }
}
