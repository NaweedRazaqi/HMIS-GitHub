using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entity.look
{
    public class EmaraType
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
