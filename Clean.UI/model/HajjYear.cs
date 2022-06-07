using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class HajjYear
    {
        public HajjYear()
        {
            MoneyBack = new HashSet<MoneyBack>();
        }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int EnrollmentId { get; set; }
        public int ArchiveNo { get; set; }
        public int ProvincesId { get; set; }
        public int? CreatedBy { get; set; }
        public int Id { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location Provinces { get; set; }
        public virtual Year Year { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
    }
}
