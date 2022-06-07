using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Lookup.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public string CompanyName { get; set; }
        public string ContractDetails { get; set; }
    }
}
