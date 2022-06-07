using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class HajyearlyCapacity
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public long? TotalCapacity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Year Year { get; set; }
    }
}