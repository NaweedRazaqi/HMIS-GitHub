using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class TicketDiscount
    {
        public TicketDiscount()
        {
            Installment = new HashSet<Installment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Installment> Installment { get; set; }
    }
}
