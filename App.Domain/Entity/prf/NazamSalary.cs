using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class NazamSalary
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public int NazamId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public virtual Candidate Nazam { get; set; }
    }
}
