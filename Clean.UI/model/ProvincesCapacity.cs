using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class ProvincesCapacity
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? ProvinceId { get; set; }
        public int? TotalId { get; set; }
        public long? ProvinceCapacity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Location Province { get; set; }
        public virtual Year Year { get; set; }
    }
}
