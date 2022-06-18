using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class HajjYearlyFee
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public decimal? Fee { get; set; }

        public virtual Year Year { get; set; }
    }
}
