using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public required string Text { get; set; } = string.Empty;
        public required DateTime SendDate { get; set; }

        public required Guid UserId { get; set; }
        public required Guid ChatId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Chat Chat { get; set; } = null!;

        public required bool IsDeleted { get; set; }
    }
}
