using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class Currency
    {
        public Currency() {
            DailyExpense = new HashSet<DailyExpense>();
            ReturnMoney = new HashSet<ReturnMoney>();
            Installment = new HashSet<Installment>();
            MutamidCashes = new HashSet<MutamidCashes>();
            MoneyBack = new HashSet<MoneyBack>();
            ContractInstallment = new HashSet<ContractInstallment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public virtual ICollection<DailyExpense> DailyExpense { get; set; }
        public virtual ICollection<ReturnMoney> ReturnMoney { get; set; }
        public virtual ICollection<Installment> Installment { get; set; }
        public virtual ICollection<MutamidCashes> MutamidCashes { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
        public virtual ICollection<ContractInstallment> ContractInstallment { get; set; }
    }
}
