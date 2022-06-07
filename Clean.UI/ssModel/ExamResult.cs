using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
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
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<ExamScore> ExamScore { get; set; }
    }
}
