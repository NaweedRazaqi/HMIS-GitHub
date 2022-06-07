using App.Domain.Entity.look;
using System;

namespace App.Domain.Entity.prf
{
    public partial class Qouta
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? QoutaAmount { get; set; }
        public int? YearId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CreatedBy { get; set; }
        public virtual SpecialEntityType Organization { get; set; }
        public virtual Year Year { get; set; }
    }
}
