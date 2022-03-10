using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class AssessmentResultGroup
    {
        public AssessmentResultGroup()
        {
            AssessmentUserResults = new HashSet<AssessmentUserResult>();
            Assessments = new HashSet<Assessment>();
            Options = new HashSet<Option>();
            ResultTips = new HashSet<ResultTip>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AssessmentUserResult> AssessmentUserResults { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<ResultTip> ResultTips { get; set; }
    }
}
