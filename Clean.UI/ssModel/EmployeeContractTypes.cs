using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class EmployeeContractTypes
    {
        public EmployeeContractTypes()
        {
            Wages = new HashSet<Wages>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Wages> Wages { get; set; }
    }
}
