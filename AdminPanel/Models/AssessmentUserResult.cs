using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class AssessmentUserResult
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public int UserId { get; set; }
        public int AssessmentResultGroupId { get; set; }
        public float Score { get; set; }

        public virtual Assessment Assessment { get; set; } = null!;
        public virtual AssessmentResultGroup AssessmentResultGroup { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
