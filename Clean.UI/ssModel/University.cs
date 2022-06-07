using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class University
    {
        public University()
        {
            Education = new HashSet<Education>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Education> Education { get; set; }
    }
}
