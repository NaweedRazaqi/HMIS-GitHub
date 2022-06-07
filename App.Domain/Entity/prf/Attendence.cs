using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Attendence
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public int NazamId { get; set; }
        public int AttendenceTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalAbsetn { get; set; }
        public int TotalPresent { get; set; }

        public virtual AddressType AttendenceType { get; set; }
        public virtual Candidate Nazam { get; set; }
    }
}
