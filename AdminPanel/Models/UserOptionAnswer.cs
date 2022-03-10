using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class UserOptionAnswer
    {
        public int Id { get; set; }
        public int OptionsId { get; set; }
        public int? UserId { get; set; }
        public int AssessmentId { get; set; }

        public virtual Assessment Assessment { get; set; } = null!;
        public virtual Option Options { get; set; } = null!;
        public virtual User? User { get; set; }
    }
}
