using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Mosque
    {
        public Mosque()
        {
            NazamToMosque = new HashSet<NazamToMosque>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Location District { get; set; }
        public virtual Location Province { get; set; }
        public virtual ICollection<NazamToMosque> NazamToMosque { get; set; }
    }
}
