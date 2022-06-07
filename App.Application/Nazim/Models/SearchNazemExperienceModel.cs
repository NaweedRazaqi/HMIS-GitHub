using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Nazim.Models
{
   public class SearchNazemExperienceModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? PrevouseHajCount { get; set; }
        public int? ExpenseType { get; set; }
        public int? YearId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CandidateName { get; set; }
        public string? Pervoushajexperience { get; set; }
        public string? ExpenseTypeText { get; set; }
        public int? Yearname { get; set; }
    }
}
