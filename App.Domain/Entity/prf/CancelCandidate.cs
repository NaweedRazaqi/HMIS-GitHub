using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class CancelCandidate
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public string CancelReasons { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
