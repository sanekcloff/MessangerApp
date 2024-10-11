using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class User
    {
        public User() { }
        public User(byte[] image, string nickname, string email, string login, string password)
        {
            Id = Guid.NewGuid();
            Image = image;
            Color = string.Empty;
            Nickname = nickname;
            Tag = string.Empty;
            CustomStatus = null;
            Email = email;
            Login = login;
            PasswordHash = password;
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

    }
    public enum Statuses
    {
        Online = 0,
        IsBussy = 1,
        IsMoveAway = 2,
        Offline = 3
    }
}
