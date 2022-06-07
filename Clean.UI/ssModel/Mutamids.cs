using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Mutamids
    {
        public Mutamids()
        {
            DailyExpense = new HashSet<DailyExpense>();
            MobileCards = new HashSet<MobileCards>();
            MutamidAccounts = new HashSet<MutamidAccounts>();
            MutamidCashes = new HashSet<MutamidCashes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Jobtitle { get; set; }
        public string Office { get; set; }
        public int? ProvincesId { get; set; }
        public int? DistrictsId { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Location Districts { get; set; }
        public virtual Location Provinces { get; set; }
        public virtual ICollection<DailyExpense> DailyExpense { get; set; }
        public virtual ICollection<MobileCards> MobileCards { get; set; }
        public virtual ICollection<MutamidAccounts> MutamidAccounts { get; set; }
        public virtual ICollection<MutamidCashes> MutamidCashes { get; set; }
    }
}
