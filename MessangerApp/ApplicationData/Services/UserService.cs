using ApplicationData.Core.Context;
using ApplicationData.Handlers;
using ApplicationData.Interfaces;
using ApplicationData.Models;
using ApplicationData.Utilities.Converters;
using ApplicationData.Utilities.Enums;
using ApplicationData.Utilities.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Services
{
    public static class UserService
    {
        public static User Login(string email, string password, AppDbContext context)
        {
            var salts = context.Users.Select(x => x.Salt).ToList();
            string hashedPassword;
            foreach (var salt in salts)
            {
                hashedPassword = PasswordHasher.HashPassword(password, salt);
                var currentUser = context.Users.Where(u => u.Email == email & u.PasswordHash == hashedPassword).FirstOrDefault();
                if (currentUser!=null) 
                {
                    Debug.WriteLine("Учётная запись найдена");
                    return currentUser;
                }
            }
            Debug.WriteLine("Учётная запись с такими данными не найдена");
            return null!;
        }
        public static string Create(string nickname,string email, string password, string imagePath, AppDbContext context)
        {
            var user = new User() { Email = email, Nickname = nickname };
            // Автоматически генерируются
            var random = new Random();
            user.Id = GetIdentityId(context);
            user.Color = ColorGenerator.GenerateHexColor(random);
            user.Tag = TagGenerator.GenerateTag(user.Nickname, random, context);
            user.Salt = PasswordHasher.GenerateSalt();
            user.PasswordHash = PasswordHasher.HashPassword(password, user.Salt);
            user.CustomStatus = null;
            user.CreationDate = DateTime.Now;
            user.LastActive = DateTime.Now;
            user.Status = Statuses.Offline;
            user.IsDeleted = false;
            user.IsOnline = false;
            user.Image = !string.IsNullOrEmpty(imagePath) ? ImageConverter.ImageToBytes(imagePath) : null;
            var result = new UserHandler().Add(user, context);
            Debug.WriteLine(result.Item1);
            return result.Item2;
        }
        private static Guid GetIdentityId(AppDbContext context)
        {
            var id = Guid.NewGuid();
            while (true)
            {
                if (!context.Users.Any(u => u.Id == id)) return id;
                id = Guid.NewGuid();
            }
        }
    }
}
