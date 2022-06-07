using App.Domain.Entity.look;
using Clean.Domain.Entity.look;
using System;
using System.Collections.Generic;
using Currency = App.Domain.Entity.look.Currency;

namespace App.Domain.Entity.prf
{

    public partial class Installment
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int InstallmentTypeId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int RecipetNo { get; set; }
        public int BankId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyRate { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? InstallmentNo { get; set; }
        public int? DiscountId { get; set; }
        public int? Amountofdiscount { get; set; }
        public int? OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public int? OrdererId { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual TicketDiscount Discount { get; set; }
        public virtual InstallmentType InstallmentType { get; set; }
        public virtual Order Order { get; set; }
        public virtual TicketOrder Orderer { get; set; }
    }
}
