using System;
using System.Collections.Generic;
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

        public required int StatusId { get; set; }
        public virtual Status Status { get; set; } = null!;

        public required bool IsDeleted { get; set; }

        public virtual ICollection<Chat> Chats { get; set; } = null!;

        [NotMapped]
        public string Username { get => $"{Nickname}:{Tag}"; }
        
    }
}
