using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Evcategory
    {
        public Evcategory()
        {
            Nerecords = new HashSet<Nerecords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ZoneId { get; set; }

        public virtual Evzone Zone { get; set; }
        public virtual ICollection<Nerecords> Nerecords { get; set; }
    }
}
