using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class CandidateStatus
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int StatusTypeId { get; set; }
        public int CprovincesId { get; set; }
        public string RoomNo { get; set; }
        public string Remarks { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location Cprovinces { get; set; }
        public virtual StatusType StatusType { get; set; }
    }
}
