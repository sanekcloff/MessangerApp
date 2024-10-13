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
using System.Diagnostics;
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
            user.Id = GetIdentityId(context);
            user.Color = ColorGenerator.GenerateHexColor(random);
            user.Tag = TagGenerator.GenerateTag(user.Nickname, random, context);
            user.Salt = PasswordHasher.GenerateSalt();
            user.PasswordHash = PasswordHasher.HashPassword(user.Password, user.Salt);
            user.CustomStatus = null;
            user.CreationDate = DateTime.Now;
            user.LastActive = DateTime.Now;
            user.Status = Statuses.Offline;
            user.IsDeleted = false;
            user.Image = !string.IsNullOrEmpty(user.ImagePath) ? ImageConverter.ImageToBytes(user.ImagePath) : null;
            var result = new UserHandler().Add(user, context);
            Debug.WriteLine(result.Item1);
            return result.Item2;
        }
        static Guid GetIdentityId(AppDbContext context)
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
