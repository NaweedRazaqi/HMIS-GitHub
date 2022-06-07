using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Report.Models
{
   public class ExportReport
    {
        //Candidate
        public int? Id { get; set; }
        public string IsSelected { get; set; }
        public int? Hajjid { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Gender { get; set; }
        public int? GenderId { get; set; }
        public int? ReligionId { get; set; }
        public string Religion { get; set; }
        public int? CandidateTypesId { get; set; }
        public string CandidateDariName { get; set; }
        public int? YearId { get; set; }
        public string GenderName { get; set; }
        public int? CandidateId { get; set; }
        public int YearName { get; set; }
        // address
        public int? CProvinceId { get; set; }
        public int? CDistrictId { get; set; }
        public string CfullAdd { get; set; }
        public int? PProvinceId { get; set; }
        public int? PDistrictId { get; set; }
        public string PfullAdd { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CProvinceName { get; set; }
        public string CDistrictName { get; set; }
        public string PDistrictName { get; set; }
        public string PProvinceName { get; set; }
        public string CandidateName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //relative

        //public int Nidno { get; set; }
        //public string Profession { get; set; }
        public int ProvincesId { get; set; }
        public string ProvincesName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        //public string FullAddress { get; set; }
        public int RelationshipId { get; set; }
        public string RelationshipName { get; set; }
   
        public string Remarks { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentTypeText { get; set; }
        public string NID { get; set; }
        public string NIDText { get; set; }
        public string TazkiraNumber { get; set; }

    }
}
