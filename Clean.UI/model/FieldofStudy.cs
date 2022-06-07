using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class FieldofStudy
    {
        public FieldofStudy()
        {
            Education1 = new HashSet<Education1>();
        }

        public long Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Education1> Education1 { get; set; }
    }
}
