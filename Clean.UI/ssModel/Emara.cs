using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Emara
    {
        public Emara()
        {
            HajjiAdditionToEmara = new HashSet<HajjiAdditionToEmara>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string FullAddress { get; set; }
        public int YearId { get; set; }
        public int? EmaraType { get; set; }
        public int? EmaraZone { get; set; }
        public int? Capacity { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual EmaraType EmaraTypeNavigation { get; set; }
        public virtual EmaraZoneType EmaraZoneNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual Year Year { get; set; }
        public virtual ICollection<HajjiAdditionToEmara> HajjiAdditionToEmara { get; set; }
    }
}
