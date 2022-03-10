using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; } = null!;
        public string? Title { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
