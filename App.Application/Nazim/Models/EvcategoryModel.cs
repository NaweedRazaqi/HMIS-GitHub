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
        public int? MarkId { get; set; }
        public int? ZoneId { get; set; }

    }
}
