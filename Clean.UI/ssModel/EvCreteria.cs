using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class EvCreteria
    {
        public EvCreteria()
        {
            Nerecords = new HashSet<Nerecords>();
        }

        public int Id { get; set; }
        public int? EvZoneTypeId { get; set; }
        public string Name { get; set; }

        public virtual Evzone EvZoneType { get; set; }
        public virtual ICollection<Nerecords> Nerecords { get; set; }
    }
}
