using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchHajjYearModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int EnrollmentId { get; set; }
        public int ArchiveNo { get; set; }
        public int ProvincesId { get; set; }
        public string CandidateName { get; set; }
        public int? YearName { get; set; }
        public string ProvincesName { get; set; }
        public bool IsCanceled { get; set; }

    }
}
