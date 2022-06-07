using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.YearlyCapacity.Models
{
    public class SearchCapacityModel
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? ProvinceId { get; set; }
        public long? ProvinceCapacity { get; set; }
        public string Provinces { get; set; }
        public long? TotalCapacity { get; set; }
        public int? YearName { get; set; }
        public int? Remain { get; set; }
    }
}
