using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationData.Models
{
    public class Status
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required bool IsBusy { get; set; }
        public required bool IsMovedAway { get; set; }
        public required bool IsDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; } = null!;    
    }
}
