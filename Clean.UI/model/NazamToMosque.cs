using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class NazamToMosque
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int MosqueId { get; set; }
        public int? CreatedBy { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Mosque Mosque { get; set; }
    }
}
