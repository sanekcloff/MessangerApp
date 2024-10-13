using ApplicationData.Core.Context;
using ApplicationData.Utilities.Enums;
using ApplicationData.Utilities.Generators;
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
        public User(byte[] image, string nickname, string email, string login, string password)
        {
            Image = image;
            Nickname = nickname;
            CustomStatus = null;
            Email = email;
            Login = login;
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
        public string Salt { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        
        public Statuses Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = null!;

        [NotMapped]
        public string Username => $"{Nickname}:{Tag}";
        public string CreationDateFormated => CreationDate.ToString("f");
        public string LastActiveFormated => CreationDate.ToString("f");      
        public string ImagePath { get; set; }
    }
}
