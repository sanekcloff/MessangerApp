using ApplicationData.Core.Context;
using Messanger.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(AppDbContext context)
        {
            this.context = context;
        }
        #region Fields & Properties
        
        private AppDbContext context;
        private string email;
        private string password;
        private string imagePath;

        public string Email { get => email; set => Set(ref email, value, nameof(Email)); }
        public string Password { get => password; set => Set(ref password, value, nameof(Password)); }
        public string ImagePath { get => imagePath; set => Set(ref imagePath, value, nameof(ImagePath)); }

        #endregion
    }
}
