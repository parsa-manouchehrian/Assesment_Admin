using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class ResetPasswordRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid Token { get; set; }
        public DateTime ExpiryDateTime { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
