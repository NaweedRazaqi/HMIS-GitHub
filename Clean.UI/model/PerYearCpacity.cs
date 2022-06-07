using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class PerYearCpacity
    {
        public long Id { get; set; }
        public long? CandidatId { get; set; }
        public long? ProvinceId { get; set; }
        public long? YearId { get; set; }
    }
}
