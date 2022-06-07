using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class InstallmentType
    {
        public InstallmentType()
        {
            Installment = new HashSet<Installment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Installment> Installment { get; set; }
    }
}
