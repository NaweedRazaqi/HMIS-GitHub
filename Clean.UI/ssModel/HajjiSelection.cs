using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class HajjiSelection
    {
        public int? Id { get; set; }
        public bool? IsSelected { get; set; }
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
    }
}
