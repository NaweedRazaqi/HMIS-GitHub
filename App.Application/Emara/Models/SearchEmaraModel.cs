using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Emara.Models
{
    public class SearchEmaraModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string FullAddress { get; set; }
        public int YearId { get; set; }
        public int? EmaraType { get; set; }
        public int? EmaraZone { get; set; }
        public int? Capacity { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string LocationName { get; set; }
        public int? YearName { get; set; }
        public string EmaraZoneName { get; set; }
        public string EmaraTypeName { get; set; }

       
    }
}
