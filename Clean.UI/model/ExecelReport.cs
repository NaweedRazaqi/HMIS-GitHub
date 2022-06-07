using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class ExecelReport
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public int? ArcheiveNo { get; set; }
        public string Gender { get; set; }
        public string CurrentProvince { get; set; }
        public string CurrentDistricts { get; set; }
        public string PerminantProvince { get; set; }
        public string PerminantDistricts { get; set; }
        public string Religion { get; set; }
        public string CandidateType { get; set; }
        public string MahramFirstName { get; set; }
        public string MahramLastName { get; set; }
    }
}
