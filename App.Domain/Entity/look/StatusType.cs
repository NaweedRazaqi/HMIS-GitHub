using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class StatusType
    {
        public StatusType()
        {
            Status = new HashSet<Status>();
            CandidateStatus = new HashSet<CandidateStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }
        public virtual ICollection<Status> Status { get; set; }
        public virtual ICollection<CandidateStatus> CandidateStatus { get; set; }
    }
}
