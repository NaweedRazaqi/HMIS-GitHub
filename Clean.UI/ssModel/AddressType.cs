using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class AddressType
    {
        public AddressType()
        {
            Attendence = new HashSet<Attendence>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attendence> Attendence { get; set; }
    }
}
