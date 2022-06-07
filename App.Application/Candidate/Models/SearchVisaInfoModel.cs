using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchVisaInfoModel
    {
        public int Id { get; set; }
        public int? VisaTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueDateShamsi { get; set; }
        public DateTime ExpairyDate { get; set; }
        public string ExpairyDateShamsi { get; set; }
        public int StayDays { get; set; }
        public string VisaNo { get; set; }
        public string VisaTypeName { get; set; }
    }
}
