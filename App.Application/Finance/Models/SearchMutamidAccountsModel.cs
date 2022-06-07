using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Finance.Models
{
    public class SearchMutamidAccountsModel
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int MutamidId { get; set; }
        public int Amount { get; set; }
        public int YearId { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string CurrencyName { get; set; }
        public int? YearName { get; set; }
        public string MutamidName { get; set; }
    }
}
