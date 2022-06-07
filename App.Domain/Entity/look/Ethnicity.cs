using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entity.look
{
   public class Ethnicity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? CountryId { get; set; }
    }
}
