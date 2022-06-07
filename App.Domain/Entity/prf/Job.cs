using App.Domain.Entity.look;
using System;
namespace App.Domain.Entity.prf
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
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? RankId { get; set; }
        public string? JobTitleText { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location District { get; set; }
        public virtual JobTitle JobTilte { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Location Province { get; set; }
        public virtual Rank Rank { get; set; }


    }
}