using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace App.Application.Lookup.Models
{
    public class SpecialEntityTypeModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Code { get; set; }
        public int? TypeId { get; set; }
        public int? ParentId { get; set; }

    }
}