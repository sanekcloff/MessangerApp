using ApplicationData.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class User
    {
        public User() { }
        public User(byte[] image, string nickname, string email, string login, string password)
        {
            var random = new Random();

            Id = Guid.NewGuid();
            Image = image;
            Color = GenerateHexColor(random);
            Nickname = nickname;
            Tag = GenerateTag(random, nickname);
            CustomStatus = null;
            Email = email;
            Login = login;
            PasswordHash = HashPassword(password);
            CreationDate = DateTime.Now;
            LastActive = DateTime.Now;
            Status = Statuses.Offline;
            IsDeleted = false;

        }
        public Guid Id { get; set; }

        public byte[] Image { get; set; } = [];
        public string Color { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty; 
        public string Tag { get; set; } = string.Empty;
        public string? CustomStatus { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        
        public Statuses Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = null!;

        [NotMapped]
        public string Username => $"{Nickname}:{Tag}";
        public string CreationDateFormated => CreationDate.ToString("f");
        public string LastActiveFormated => CreationDate.ToString("f");

        string GenerateTag(Random random,string nickname)
        {
            var tag = string.Empty;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    tag += random.Next(0,10);
                    using (AppDbContext ctx = new())
                    {
                        var isExist = ctx.Users.Any(u => u.Nickname == nickname && u.Tag == tag);
                        if (!isExist)
                            return tag;                            
                    }
                }
            }
        }
        string GenerateHexColor(Random random)
        {
            // Генерируем три случайных числа от 0 до 255 для RGB
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            // Преобразуем в формат HEX
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] saltedPassword = Encoding.UTF8.GetBytes(GenerateSalt() + password);
                byte[] hashedPassword = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashedPassword);
            }
        }
        string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
    public enum Statuses
    {
        Online = 0,
        IsBussy = 1,
        IsMoveAway = 2,
        Offline = 3
    }
}
