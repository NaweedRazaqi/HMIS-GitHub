using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.YearlyCapacity.Models
{
    public class SearchProvinceCapacityModel
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? ProvinceId { get; set; }
        public int? TotalId { get; set; }
        public long? ProvinceCapacity { get; set; }
        public string Provinces { get; set; }
        public long? TotalCapacity { get; set; }
        public int? YearName { get; set; }
        public long? Remain { get; set; }

        public int? CandidateTypeId { get; set; }
        public string? CandidateTypeIdText { get; set; }
    }
}
