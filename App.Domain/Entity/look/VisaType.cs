using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class VisaType
    {
        public VisaType()
        {
            VisaInfo = new HashSet<VisaInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VisaInfo> VisaInfo { get; set; }
    }
}
