using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class ReturnMoney
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public int Code { get; set; }
        public int CandidateId { get; set; }
        public int RelativeId { get; set; }
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Justification { get; set; }
        public int Remarks { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Relative Relative { get; set; }
    }
}
