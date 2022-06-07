using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class ExamQuestion
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }
    }
}
