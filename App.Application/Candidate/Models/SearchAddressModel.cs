using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchAddressModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? CProvinceId { get; set; }
        public int? CDistrictId { get; set; }
        public string CfullAdd { get; set; }
        public int? PProvinceId { get; set; }
        public int? PDistrictId { get; set; }
        public string PfullAdd { get; set; }
        public string? Mobile { get; set; }
        public int? DistrictNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CProvinceName { get; set; }
        public string CDistrictName { get; set; }
        public string PDistrictName { get; set; }
        public string PProvinceName { get; set; }
        public string CandidateName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
