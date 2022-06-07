using App.Domain.Entity.look;
using System;
using System.Collections.Generic;
using Currency = App.Domain.Entity.look.Currency;

namespace App.Domain.Entity.prf
{
    public partial class ContractInstallment
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int InstallmentNo { get; set; }
        public int YearId { get; set; }
        public int CurrencyId { get; set; }
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
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Year Year { get; set; }
    }
}
