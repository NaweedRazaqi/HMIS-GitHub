using System;
using System.Collections.Generic;

namespace App.Application.Lookup.Models
{
    public class DocumentTypeModel
    {
        public int ID { get; set; }
        public int? ScreenID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int DocumentTypeId { get; set; }
    }
}
