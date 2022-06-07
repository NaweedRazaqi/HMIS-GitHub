using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class DailyExpense
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseTypeId { get; set; }
        public int M7number { get; set; }
        public DateTime M7date { get; set; }
        public int CurrencyId { get; set; }
        public int ConvertedCurrecyId { get; set; }
        public int ExchangeRate { get; set; }
        public string SpentFrom { get; set; }
        public int MutamidId { get; set; }
        public int NumberOfItems { get; set; }
        public string TotalHawalaAmount { get; set; }
        public int ExchangedAmount { get; set; }
        public string TaxPercentage { get; set; }
        public int Tax { get; set; }
        public string PrivateSector { get; set; }
        public string PrivateSectorPercentage { get; set; }
        public string Penalty { get; set; }
        public int NetAmount { get; set; }
        public int NumberOfPages { get; set; }
        public string MaktoobNo { get; set; }
        public DateTime MaktoobDate { get; set; }
        public int HukamNo { get; set; }
        public DateTime HumkamDate { get; set; }
        public string Comments { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ExpenseTypes ExpenseType { get; set; }
        public virtual Mutamids Mutamid { get; set; }
        public virtual Year Year { get; set; }
    }
}
