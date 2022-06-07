using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class VisaInfo
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpairyDate { get; set; }
        public int StayDays { get; set; }
        public int? CreatedBy { get; set; }
        public string VisaNo { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
