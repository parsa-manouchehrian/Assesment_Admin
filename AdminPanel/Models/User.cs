using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class User
    {
        public User()
        {
            AssessmentUserResults = new HashSet<AssessmentUserResult>();
            Assessments = new HashSet<Assessment>();
            PhoneValidations = new HashSet<PhoneValidation>();
            ResetPasswordRequests = new HashSet<ResetPasswordRequest>();
            UserLogins = new HashSet<UserLogin>();
            UserOptionAnswers = new HashSet<UserOptionAnswer>();
        }

        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public int ProvinceId { get; set; }
        public string? UserStatusName { get; set; }
        public bool? HasAcceptAgreement { get; set; }
        public bool? HasAcceptResearchParticipation { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual UserStatus? UserStatusNameNavigation { get; set; }
        public virtual ICollection<AssessmentUserResult> AssessmentUserResults { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<PhoneValidation> PhoneValidations { get; set; }
        public virtual ICollection<ResetPasswordRequest> ResetPasswordRequests { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserOptionAnswer> UserOptionAnswers { get; set; }
    }
}
