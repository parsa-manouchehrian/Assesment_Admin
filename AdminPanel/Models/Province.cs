using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Province
    {
        public Province()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
