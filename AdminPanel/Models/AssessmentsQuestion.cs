using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class AssessmentsQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public int OrderIndex { get; set; }

        public virtual Assessment Assessment { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
