using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Question
    {
        public Question()
        {
            ExamQuestion = new HashSet<ExamQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestion { get; set; }
    }
}
