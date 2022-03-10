using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class Question
    {
        public Question()
        {
            AssessmentsQuestions = new HashSet<AssessmentsQuestion>();
            InverseNextQuestion = new HashSet<Question>();
            OptionCurrentQuestions = new HashSet<Option>();
            OptionNextQuestions = new HashSet<Option>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? Body { get; set; }
        public int? NextQuestionId { get; set; }
        public string? QuestionTypeName { get; set; }
        public string? Code { get; set; }

        public virtual Question? NextQuestion { get; set; }
        public virtual QuestionType? QuestionTypeNameNavigation { get; set; }
        public virtual ICollection<AssessmentsQuestion> AssessmentsQuestions { get; set; }
        public virtual ICollection<Question> InverseNextQuestion { get; set; }
        public virtual ICollection<Option> OptionCurrentQuestions { get; set; }
        public virtual ICollection<Option> OptionNextQuestions { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
