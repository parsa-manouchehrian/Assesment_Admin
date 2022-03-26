using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class ResultTip
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool IsLink { get; set; }
        public bool IsActive { get; set; }
        public int AssessmentResultGroupId { get; set; }
        public string? Title { get; set; }

        public virtual AssessmentResultGroup AssessmentResultGroup { get; set; } = null!;
    }
}
