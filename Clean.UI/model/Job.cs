using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Job
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? OrganizationId { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? JobTilteId { get; set; }
        public string JobTitle { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual JobTitle JobTilte { get; set; }
        public virtual JobTitle Organization { get; set; }
    }
}
