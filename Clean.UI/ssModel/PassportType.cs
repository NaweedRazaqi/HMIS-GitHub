using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class PassportType
    {
        public PassportType()
        {
            Passport = new HashSet<Passport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Passport> Passport { get; set; }
    }
}
