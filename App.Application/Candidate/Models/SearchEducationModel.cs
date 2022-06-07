using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
   public class SearchEducationModel
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public string Startdates { get; set; }
        public DateTime? EndDate { get; set; }
        public string Enddates { get; set; }
        public int? CandidateId { get; set; }
        public int? DegreeId { get; set; }
        public long? FieldofstudyId { get; set; }
        public int? CountryId { get; set; }
        public int? UniversityId { get; set; }
        public int? StudyTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CountryName { get; set; }
        public string Fieldofstudy { get; set; }
        public string Degree { get; set; }
        public string University { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public decimal? Synced { get; set; }
    }
}
