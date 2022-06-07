using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Sscandidate
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? YearId { get; set; }
        public int? ProvinceId { get; set; }
        public int? GenderId { get; set; }
        public bool? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Address Province { get; set; }
        public virtual Year Year { get; set; }
    }
}
