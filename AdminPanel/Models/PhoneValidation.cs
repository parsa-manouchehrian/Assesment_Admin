using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class PhoneValidation
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
