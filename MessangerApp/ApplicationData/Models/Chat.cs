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
        public Chat() { }
        public Chat(string title, bool isGroup)
        {
            Id = new Guid();
            Title = title;
            CreationDate = DateTime.Now;
            IsGroup = isGroup;
            IsDeleted = false;
        }
        public  Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

        public bool IsGroup { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; } = null!;
    }
}
