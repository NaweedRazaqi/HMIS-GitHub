using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
   public class SelectCandidateModel
    {
        public int Id { get; set; }
        public string age { get; set; }
        public string EnrollmentDate { get; set; }
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
        //public int? SpecialEntityId { get; set; }
        public int? MahramId { get; set; }
        public string Mahram { get; set; }
        public string RMahram { get; set; }
        public int? RelationshipId { get; set; }
        public int CandidateTypeId { get; set; }
        public string CandidateTypeName { get; set; }
        public int? NazamCategoryId { get; set; }
        public string Remarks { get; set; }
        public string IsSelected { get; set; }
        public string IsCanceledName { get; set; }
        public bool IsCanceled { get; set; }
        public string PhotoPath { get; set; }
        public int? LanguageId { get; set; }
        public int? ArchiveNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string YearName { get; set; }
        public int CandidateId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int YearId { get; set; }
        public int HajiStatusId { get; set; }
        public string cancelhaji { get; set; }
        //for prints
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string ProvinceName { get; set; }
        public string DestrictName { get; set; }
        public string Vilage { get; set; }
        public string JobTitle { get; set; }

        public string DocumentTypeText { get; set; }
        public string NID { get; set; }
        public string NIDText { get; set; }
        public string TazkiraNumber { get; set; }
    }
}
