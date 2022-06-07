using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchContractModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractDetails { get; set; }
        public string CompanyName { get; set; }
        public int LocationId { get; set; }
        public int ExpenseCenterId { get; set; }
        public int ContractNumber { get; set; }
        public int ContractAmount { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public string LocationName { get; set; }
        public string ExpenseCenterName { get; set; }
        public string DateShamsi { get; set; }
        public string StartDateShamsi { get; set; }
        public string EndDateShamsi { get; set; }
    }
}
