using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class SpecialEntity
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
        public int? SpecialEntityTypeId { get; set; }
        public int? YearId { get; set; }
        public int? CandidateId { get; set; }
        public int? OrganizationId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DepartmentName { get; set; }
        public int? MaktubNumber { get; set; }
        public DateTime? Date { get; set; }
        public string Refrence { get; set; }
        public string Discription { get; set; }
        public string ShoraName { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual SpecialEntityType Organization { get; set; }
        public virtual SpecialEntityType SpecialEntityType { get; set; }
        public virtual Year Year { get; set; }
    }
}
