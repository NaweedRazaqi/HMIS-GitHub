using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Mosque.Models
{
    public class SearchMosqueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }

    }
}
