using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class ExamScore
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int ExamResultId { get; set; }
        public int TotalMarks { get; set; }
        public int? OralExamScore { get; set; }
        public int? WrittenExamScore { get; set; }  


        public virtual Candidate Candidate { get; set; }
        public virtual ExamResult ExamResult { get; set; }

     

    }
}
