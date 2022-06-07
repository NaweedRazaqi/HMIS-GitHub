using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Qouta.Models
{
    public class SearchQoutaModel
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public string organName { get; set; }
        public int? remain { get; set; }
        public int? QoutaAmount { get; set; }
        public int? YearId { get; set; }
        public string Year { get; set; }
    }
}
