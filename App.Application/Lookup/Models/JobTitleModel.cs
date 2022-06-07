using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Lookup.Models
{
   public class JobTitleModel
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? OrganizationId { get; set; }
        public string Title { get; set; }
        public string Dari { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
      

    }
}
