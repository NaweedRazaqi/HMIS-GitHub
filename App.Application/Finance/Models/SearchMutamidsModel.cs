using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchMutamidsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Jobtitle { get; set; }
        public string Office { get; set; }
        public int? ProvincesId { get; set; }
        public int? DistrictsId { get; set; }
        public int IsActive { get; set; }
        public string IsActiveName { get; set; }
        public string ProvincesName { get; set; }
        public string DistrictsName { get; set; }

    }
}
