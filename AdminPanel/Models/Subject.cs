using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Assessments = new HashSet<Assessment>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? FirstQuestionId { get; set; }

        public virtual Question? FirstQuestion { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
