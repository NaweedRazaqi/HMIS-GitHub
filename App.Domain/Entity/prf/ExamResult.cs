using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class ExamResult
    {
        public ExamResult()
        {
            ExamScore = new HashSet<ExamScore>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }

        public virtual ICollection<ExamScore> ExamScore { get; set; }
    }
}
