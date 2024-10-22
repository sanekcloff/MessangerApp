using ApplicationData.Core.Context;
using ApplicationData.Utilities.Enums;
using ApplicationData.Utilities.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public byte[]? Image { get; set; } = [];
        public string Color { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty; 
        public string Tag { get; set; } = string.Empty;
        public string? CustomStatus { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        
        public Statuses Status { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsOnline { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = null!;

        [NotMapped]
        public string Username => $"{Nickname}#{Tag}";
        public string CreationDateFormated => CreationDate.ToString("f");
        public string LastActiveFormated => CreationDate.ToString("f");
        public string ImagePath() => string.Empty;
        public string Password() => string.Empty;

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                Debug.WriteLine("DEBUG: Объект сравнения имеет значение NULL!");
                return false;
            }
            else if (GetType() != obj.GetType())
            {
                Debug.WriteLine("DEBUG: Объекты имеют разные типы данных!");
                return false;
            }
            var entity = (User)obj;

            return Email == entity.Email;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nickname, Tag);
        }
    }
}
