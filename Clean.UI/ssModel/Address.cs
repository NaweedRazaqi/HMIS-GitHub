using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Address
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string CfullAdd { get; set; }
        public string PfullAdd { get; set; }
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        public int? CprovinceId { get; set; }
        public int? CdistrictId { get; set; }
        public int? PprovinceId { get; set; }
        public int? PdistrictId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int? DistrictNumber { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location Cdistrict { get; set; }
        public virtual Location Cprovince { get; set; }
        public virtual Location Pdistrict { get; set; }
        public virtual Location Pprovince { get; set; }
    }
}
