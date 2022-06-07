using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchWageModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int EmployeeContractTypeId { get; set; }
        public string EmployeeContractTypeName { get; set; }
        public string JobTitle { get; set; }
        public string WorkingCommitee { get; set; }
        public int? PerDayWage { get; set; }
        public int NoOfDays { get; set; }
        public int TotalWage { get; set; }
        public int? AbsentyDeduction { get; set; }
        public int? TaxDeduction { get; set; }
        public int? TotalPayment { get; set; }
        public string Comments { get; set; }
    }
}
