using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class Year
    {
        public Year()
        {
            Apportioment = new HashSet<Apportioment>();
            ContractInstallment = new HashSet<ContractInstallment>();
            DailyExpense = new HashSet<DailyExpense>();
            Emara = new HashSet<Emara>();
            HajjYear = new HashSet<HajjYear>();
            HajyearlyCapacity = new HashSet<HajyearlyCapacity>();
            MoneyBack = new HashSet<MoneyBack>();
            MutamidAccounts = new HashSet<MutamidAccounts>();
            ProvincesCapacity = new HashSet<ProvincesCapacity>();
            Qouta = new HashSet<Qouta>();
            SpecialEntity = new HashSet<SpecialEntity>();
            Sscandidate = new HashSet<Sscandidate>();
            TicketInfo = new HashSet<TicketInfo>();
            HajjiAdditionToEmaras = new HashSet<HajjiAdditionToEmara>();
        }

        public int Id { get; set; }
        public int? Name { get; set; }

        public virtual ICollection<Apportioment> Apportioment { get; set; }
        public virtual ICollection<ContractInstallment> ContractInstallment { get; set; }
        public virtual ICollection<DailyExpense> DailyExpense { get; set; }
        public virtual ICollection<Emara> Emara { get; set; }
        public virtual ICollection<HajjYear> HajjYear { get; set; }
        public virtual ICollection<HajyearlyCapacity> HajyearlyCapacity { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
        public virtual ICollection<MutamidAccounts> MutamidAccounts { get; set; }
        public virtual ICollection<ProvincesCapacity> ProvincesCapacity { get; set; }
        public virtual ICollection<Qouta> Qouta { get; set; }
        public virtual ICollection<SpecialEntity> SpecialEntity { get; set; }
        public virtual ICollection<Sscandidate> Sscandidate { get; set; }
        public virtual ICollection<TicketInfo> TicketInfo { get; set; }
        public virtual ICollection<HajjiAdditionToEmara> HajjiAdditionToEmaras { get; set; }
    }
}
