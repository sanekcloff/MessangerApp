using ApplicationData.Core.Context;
using ApplicationData.Models;
using ApplicationData.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger.ViewModels
{
    public class AuthorizationViewModel
    {
        public AuthorizationViewModel(AppDbContext context)
        {
            this.context = context;
            CurrentUser = new();
        }
        // Поле для хранения контекста
        private AppDbContext context;
        // Свойство для работы с User
        public User CurrentUser { get; set; }
        // Метод регистрации нового пользователя
        public void RegistrateUser()
        {
            Debug.WriteLine(UserService.Create(CurrentUser, context));
        }
    }

    public class RegisterationViewModel
    {
        public RegisterationViewModel(AppDbContext context)
        {
            this.context = context;
        }

        private AppDbContext context;

        public User CurrentUser;

        public void RegistrateUser()
        {
            Debug.WriteLine(UserService.Create(CurrentUser, context));
        }
    }
    public class LoginViewModel
    {
        public LoginViewModel(AppDbContext context)
        {
            this.context = context;
        }
        private AppDbContext context;
    }
}
