using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Contract
    {
        public Contract()
        {
            ContractInstallment = new HashSet<ContractInstallment>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractDetails { get; set; }
        public string CompanyName { get; set; }
        public int LocationId { get; set; }
        public int ExpenseCenterId { get; set; }
        public int ContractNumber { get; set; }
        public int ContractAmount { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public virtual ExpenseCenters ExpenseCenter { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ContractInstallment> ContractInstallment { get; set; }
    }
}
