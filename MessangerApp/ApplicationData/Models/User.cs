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
        public Guid Id { get; set; }

        public byte[] Image { get; set; } = [];
        public string ImageBackground { get; set; } = string.Empty;
        public required string Nickname { get; set; } = string.Empty; 
        public required string Tag { get; set; } = string.Empty;
        public required string CustomStatus { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string Login { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
        public required string MessageColor { get; set; } = string.Empty;
        public required DateTime CreationDate { get; set; }
        public required DateTime LastActive { get; set; }
        
        public Statuses Status { get; set; }

        public required bool IsBusy { get; set; }
        public required bool IsMovedAway { get; set; }

        public required bool IsDeleted { get; set; }

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
