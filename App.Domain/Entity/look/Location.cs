using App.Domain.Entity.prf;
using Clean.Domain.Entity.look;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class Location
    {
        public Location()
        {

            ProvincesCapacity = new HashSet<ProvincesCapacity>();
            AddressCdistrict = new HashSet<Address>();
            AddressCprovince = new HashSet<Address>();
            AddressPdistrict = new HashSet<Address>();
            AddressPprovince = new HashSet<Address>();
            Apportioment = new HashSet<Apportioment>();
            CandidateStatus = new HashSet<CandidateStatus>();
            Contract = new HashSet<Contract>();
            Education = new HashSet<Education>();
            Emara = new HashSet<Emara>();
            HajjYear = new HashSet<HajjYear>();
            MosqueDistrict = new HashSet<Mosque>();
            MosqueProvince = new HashSet<Mosque>();
            MutamidsDistricts = new HashSet<Mutamids>();
            MutamidsProvinces = new HashSet<Mutamids>();
            Office = new HashSet<Office>();
            RelativeDistrict = new HashSet<Relative>();
            RelativeProvinces = new HashSet<Relative>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public string PathDari { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }
        public long? Percentage { get; set; }

        public virtual ICollection<Address> AddressCdistrict { get; set; }
        public virtual ICollection<Address> AddressCprovince { get; set; }
        public virtual ICollection<Address> AddressPdistrict { get; set; }
        public virtual ICollection<Address> AddressPprovince { get; set; }
        public virtual ICollection<Apportioment> Apportioment { get; set; }
        public virtual ICollection<CandidateStatus> CandidateStatus { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<Emara> Emara { get; set; }
        public virtual ICollection<HajjYear> HajjYear { get; set; }
        public virtual ICollection<Mosque> MosqueDistrict { get; set; }
        public virtual ICollection<Mosque> MosqueProvince { get; set; }
        public virtual ICollection<Mutamids> MutamidsDistricts { get; set; }
        public virtual ICollection<Mutamids> MutamidsProvinces { get; set; }
        public virtual ICollection<Office> Office { get; set; }
        public virtual ICollection<ProvincesCapacity> ProvincesCapacity { get; set; }
        public virtual ICollection<Relative> RelativeDistrict { get; set; }
        public virtual ICollection<Relative> RelativeProvinces { get; set; }
    }
}
