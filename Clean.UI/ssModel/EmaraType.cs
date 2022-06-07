using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class EmaraType
    {
        public EmaraType()
        {
            Emara = new HashSet<Emara>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Emara> Emara { get; set; }
    }
}
