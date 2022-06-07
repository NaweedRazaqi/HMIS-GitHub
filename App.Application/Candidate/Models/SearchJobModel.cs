using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchJobModel
    {

        public int? OrganizationId { get; set; }
        public int? Id { get; set; }
        public int? JobTilteId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int? CandidateId { get; set; }
        public string Designation { get; set; }
        public string CandidateName { get; set; }
        public string OrganizationName { get; set; }
        public string JobType { get; set; }
        public string? JobTitleText { get; set; }
        public string? ProviceText { get; set; }
        public string? DistrictText { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? RankId { get; set; }
    }
}
