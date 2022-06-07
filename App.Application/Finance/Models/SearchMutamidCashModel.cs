using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchMutamidCashModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string Explanation { get; set; }
        public int NumberMaktoob { get; set; }
        public int HukamNumber { get; set; }
        public DateTime MaktoobDate { get; set; }
        public string MaktoobDateShamsi { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int Amount { get; set; }
        public int ExchangeRate { get; set; }
        public int ExpenseCenterId { get; set; }
        public int MutamidId { get; set; }
        public string MutamidName { get; set; }
        public int IstelamNumber { get; set; }
        public DateTime IstelamDate { get; set; }
        public string IstelamDateShamsi { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
