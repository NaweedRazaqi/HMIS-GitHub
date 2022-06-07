using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchSpecialEntityModel
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
        public string SpecialEntityTypeName { get; set; }
        public int? YearName { get; set; }
        public string CandidateName { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public int? MaktubNumber { get; set; }
        public DateTime? Date { get; set; }
        public string SaveDate { get; set; }
        public int? RemainingQouta { get; set; }
        public string Refrence { get; set; }
        public string Discription { get; set; }
        public string ShoraName { get; set; }
        public int Result { get; set; }
    }
}
