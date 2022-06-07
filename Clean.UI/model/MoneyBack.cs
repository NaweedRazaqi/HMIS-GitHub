using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class MoneyBack
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
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
        public int? CreatedBy { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual HajjYear HajjYear { get; set; }
        public virtual Relative Relative { get; set; }
        public virtual Year Year { get; set; }
    }
}
