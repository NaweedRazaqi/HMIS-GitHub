using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Nazim.Models
{
  public  class EvcategoryModel
    {
        public int Id { get; set; }
        public int? Nid { get; set; }
        public string CandidateName { get; set; }
        public string zone { get; set; }
        public string result { get; set; }
        public string category { get; set; }
        public int? Evid { get; set; }
        public int? ResultId { get; set; }
        public int? ZoneId { get; set; }
        public int? EvCreteriaId { get; set; }
        public string? evCreteriaText { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
