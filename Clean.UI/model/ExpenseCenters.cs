using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class ExpenseCenters
    {
        public ExpenseCenters()
        {
            Contract = new HashSet<Contract>();
            MutamidCashes = new HashSet<MutamidCashes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<MutamidCashes> MutamidCashes { get; set; }
    }
}
