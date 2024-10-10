using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class Chat
    {
        public  Guid Id { get; set; }

        public required string Title { get; set; } = string.Empty;
        public required DateTime CreationDate { get; set; }

        public required bool IsGroup { get; set; }
        public required bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; } = null!;
    }
}
