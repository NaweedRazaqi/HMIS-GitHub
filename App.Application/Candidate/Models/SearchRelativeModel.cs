using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchRelativeModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FullAddress { get; set; }
        public int ProvincesId { get; set; }
        public string ProvincesName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int RelationshipId { get; set; }
        public string RelationshipName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Remarks { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentTypeText { get; set; }
        public string NID { get; set; }
        public string NIDText { get; set; }
        public string TazkiraNumber { get; set; }

     
    }
}
