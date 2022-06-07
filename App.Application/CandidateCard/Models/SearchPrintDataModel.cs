using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.CandidateCard.Models
{
    public class SearchPrintDataModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FirstNameEnglish { get; set; }
        public string LastNameEnglish { get; set; }
        public string FatherNameEnglish { get; set; }
        public string GrandFatherNameEnglish { get; set; }
        public string GenderName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ReligionName { get; set; }
        public string BloodGroupName { get; set; }
        public int IsInGroup { get; set; }
        public string CandidateTypeName { get; set; }
        public string Remarks { get; set; }
        public string PhotoPath { get; set; }
        public int YearName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string FullAddress { get; set; }
        public string Mahram { get; set; }
        public string RelationshipName { get; set; }
        public string PassportNo { get; set; }
        public string IssueDate { get; set; }
        public string ExpairyDate { get; set; }
        public string IssuseYear { get; set; }
        public string ExpiryYear { get; set; }
    }
}
