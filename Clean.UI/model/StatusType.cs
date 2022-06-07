using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class StatusType
    {
        public StatusType()
        {
            CandidateStatus = new HashSet<CandidateStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<CandidateStatus> CandidateStatus { get; set; }
    }
}
