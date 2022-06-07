using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
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
