using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Apportioment
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public int Quantity { get; set; }
        public int DistrictsId { get; set; }
        public int YearId { get; set; }

        public virtual Location Districts { get; set; }
        public virtual Year Year { get; set; }
    }
}
