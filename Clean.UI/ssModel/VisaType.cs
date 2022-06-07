using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
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
