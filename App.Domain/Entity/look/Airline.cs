using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class Airline
    {
        public Airline()
        {
            TicketInfo = new HashSet<TicketInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<TicketInfo> TicketInfo { get; set; }
    }
}
