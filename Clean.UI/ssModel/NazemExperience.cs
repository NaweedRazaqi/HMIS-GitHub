using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class NazemExperience
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? PrevouseHajCount { get; set; }
        public int? ExpenseType { get; set; }
        public int? YearId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Year Year { get; set; }
    }
}
