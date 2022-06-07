using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Exam
    {
        public Exam()
        {
            ExamQuestion = new HashSet<ExamQuestion>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Date { get; set; }
        public int CommiteeId { get; set; }

        public virtual Commitee Commitee { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestion { get; set; }
    }
}
