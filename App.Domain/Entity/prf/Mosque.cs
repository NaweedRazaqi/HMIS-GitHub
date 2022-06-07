using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
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
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Location District { get; set; }
        public virtual Location Province { get; set; }
        public virtual ICollection<NazamToMosque> NazamToMosque { get; set; }
    }
}
