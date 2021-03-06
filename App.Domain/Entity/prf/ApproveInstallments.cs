using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class ApproveInstallments
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string BankReceiptNo { get; set; }
        public bool? Type { get; set; }
        public DateTime Date { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
