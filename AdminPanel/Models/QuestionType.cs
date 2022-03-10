using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public string Name { get; set; } = null!;
        public string? Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
