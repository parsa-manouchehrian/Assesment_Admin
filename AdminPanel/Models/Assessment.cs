using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Assessment
    {
        public Assessment()
        {
            AssessmentUserResults = new HashSet<AssessmentUserResult>();
            AssessmentsQuestions = new HashSet<AssessmentsQuestion>();
            UserOptionAnswers = new HashSet<UserOptionAnswer>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public int SubjectId { get; set; }
        public int? UserId { get; set; }
        public string? Course { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool IsActive { get; set; }
        public int? AssessmentResultGroupId { get; set; }

        public virtual AssessmentResultGroup? AssessmentResultGroup { get; set; }
        public virtual Subject Subject { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<AssessmentUserResult> AssessmentUserResults { get; set; }
        public virtual ICollection<AssessmentsQuestion> AssessmentsQuestions { get; set; }
        public virtual ICollection<UserOptionAnswer> UserOptionAnswers { get; set; }
    }
}
