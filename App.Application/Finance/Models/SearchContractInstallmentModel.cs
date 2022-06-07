using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchContractInstallmentModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int ContractName { get; set; }
        public int InstallmentNo { get; set; }
        public int YearId { get; set; }
        public int? YearName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Amount { get; set; }
        public int ExchangeRate { get; set; }
        public int ExchangedAmount { get; set; }
        public string TaxPercentage { get; set; }
        public int Tax { get; set; }
        public string PrivateSector { get; set; }
        public string PrivateSectorPercentage { get; set; }
        public string Penalty { get; set; }
        public int NetAmount { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string Comments { get; set; }
    }
}
