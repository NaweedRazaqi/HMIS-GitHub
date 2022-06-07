using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchIdentificationModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int PassportNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpairyDate { get; set; }
        public string Remarks { get; set; }
        public string CandidateName { get; set; }
        public string IssueDateShamsi { get; set; }
        public string ExpairyDateShamsi { get; set; }
        public int? PassportTypeId { get; set; }
        public string PTypeText { get; set; }
        public string NID { get; set; }
        public string NIDText { get; set; }
        public string TazkiraNumber { get; set; }

    }
}
