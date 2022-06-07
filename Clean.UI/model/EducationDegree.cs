using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class EducationDegree
    {
        public EducationDegree()
        {
            Education1 = new HashSet<Education1>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Education1> Education1 { get; set; }
    }
}
