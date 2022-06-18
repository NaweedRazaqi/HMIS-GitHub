using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class HajjYearlyFee
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public decimal? Fee { get; set; }

        public virtual Year Year { get; set; }
    }
}
