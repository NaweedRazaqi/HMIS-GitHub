using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Currency
    {
        public Currency()
        {
            ContractInstallment = new HashSet<ContractInstallment>();
            DailyExpense = new HashSet<DailyExpense>();
            Installment = new HashSet<Installment>();
            MoneyBack = new HashSet<MoneyBack>();
            MutamidAccounts = new HashSet<MutamidAccounts>();
            MutamidCashes = new HashSet<MutamidCashes>();
            ReturnMoney = new HashSet<ReturnMoney>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }

        public virtual ICollection<ContractInstallment> ContractInstallment { get; set; }
        public virtual ICollection<DailyExpense> DailyExpense { get; set; }
        public virtual ICollection<Installment> Installment { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
        public virtual ICollection<MutamidAccounts> MutamidAccounts { get; set; }
        public virtual ICollection<MutamidCashes> MutamidCashes { get; set; }
        public virtual ICollection<ReturnMoney> ReturnMoney { get; set; }
    }
}
