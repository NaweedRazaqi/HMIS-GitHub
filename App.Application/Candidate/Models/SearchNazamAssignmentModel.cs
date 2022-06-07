using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchNazamAssignmentModel
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
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int MaritalStatusId { get; set; }
        public DateTime BirthDate { get; set; }
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public int BloodGroupId { get; set; }
        public string BloodGroupName { get; set; }
        public int IsInGroup { get; set; }
        public int? MahramId { get; set; }
        public int? RelationshipId { get; set; }
        public int CandidateTypeId { get; set; }
        public string CandidateTypeName { get; set; }
        public int? NazamCategoryId { get; set; }
        public string Remarks { get; set; }
        public string IsSelected { get; set; }
        public string IsCanceledName { get; set; }
        public int IsCanceled { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int YearName { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int? NazamCandidateId { get; set; }
        public string NazamCandidateStatus { get; set; }
        public string CandidateName { get; set; }
    }
}
