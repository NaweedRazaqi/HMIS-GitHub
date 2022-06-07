using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Qouta
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? QoutaAmount { get; set; }
        public int? YearId { get; set; }
        public string ModifiedBy { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual SpecialEntityType Organization { get; set; }
        public virtual Year Year { get; set; }
    }
}
