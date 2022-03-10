using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Country
    {
        public Country()
        {
            Provinces = new HashSet<Province>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
