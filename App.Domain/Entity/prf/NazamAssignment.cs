using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class NazamAssignment
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int NazamCandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Candidate NazamCandidate { get; set; }
    }
}
