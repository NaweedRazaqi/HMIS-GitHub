using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchMoneyBackModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int HajjYearId { get; set; }
        public string NumberMaktoobBank { get; set; }
        public DateTime MoneyReturnDate { get; set; }
        public int CurrencyId { get; set; }
        public int ReturnedAmount { get; set; }
        public int RelativeId { get; set; }
        public string Justification { get; set; }
        public string CheckedBy { get; set; }
        public string Comments { get; set; }
        public string CandidateName { get; set; }
        public int? YearName { get; set; }
        public int? HajjYearName { get; set; }
        public string CurrencyName { get; set; }
        public string MoneyReturnDateShamsi { get; set; }
        public string RelativeName { get; set; }
    }
}
