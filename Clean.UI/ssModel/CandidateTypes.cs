using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class CandidateTypes
    {
        public CandidateTypes()
        {
            Candidate = new HashSet<Candidate>();
            ProvincesCapacity = new HashSet<ProvincesCapacity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<ProvincesCapacity> ProvincesCapacity { get; set; }
    }
}
