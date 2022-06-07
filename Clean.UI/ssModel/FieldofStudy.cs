using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class FieldofStudy
    {
        public FieldofStudy()
        {
            Education = new HashSet<Education>();
        }

        public long Id { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Education> Education { get; set; }
    }
}
