using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Option
    {
        public Option()
        {
            UserOptionAnswers = new HashSet<UserOptionAnswer>();
        }

        public int Id { get; set; }
        public string? Body { get; set; }
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }
        public int CurrentQuestionId { get; set; }
        public int? NextQuestionId { get; set; }
        public int AssessmentResultGroupsId { get; set; }
        public int? Score { get; set; }

        public virtual AssessmentResultGroup AssessmentResultGroups { get; set; } = null!;
        public virtual Question CurrentQuestion { get; set; } = null!;
        public virtual Question? NextQuestion { get; set; }
        public virtual ICollection<UserOptionAnswer> UserOptionAnswers { get; set; }
    }
}
