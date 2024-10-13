using ApplicationData.Core.Context;
using ApplicationData.Handlers;
using ApplicationData.Interfaces;
using ApplicationData.Models;
using ApplicationData.Utilities.Converters;
using ApplicationData.Utilities.Enums;
using ApplicationData.Utilities.Generators;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Services
{
    public static class UserService
    {
        public static string Create(User user, AppDbContext context)
        {
            // Автоматически генерируются
            var random = new Random();
            user.Id = GetIdentityId(user, context);
            user.Color = ColorGenerator.GenerateHexColor(random);
            user.Tag = TagGenerator.GenerateTag(user.Nickname, random);
            user.Salt = PasswordHasher.GenerateSalt();
            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash, user.Salt);
            user.CustomStatus = null;
            user.CreationDate = DateTime.Now;
            user.LastActive = DateTime.Now;
            user.Status = Statuses.Offline;
            user.IsDeleted = false;
            user.Image = ImageConverter.ImageToBytes(user.ImagePath);
            new UserHandler().Add(user,context);
            return "Пользователь добавлен!";
        }
        static Guid GetIdentityId(User user, AppDbContext context)
        {
            var id = Guid.NewGuid();
            while (true)
            {
                if (!context.Users.Any(u => u.Id == user.Id)) return id;
                id = Guid.NewGuid();
            }
        }
    }
}
