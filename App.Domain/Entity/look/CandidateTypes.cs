using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class CandidateTypes
    {
        public CandidateTypes()
        {
            Candidate = new HashSet<Candidate>();
            ProvincesCapacities = new HashSet<ProvincesCapacity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<ProvincesCapacity> ProvincesCapacities { get; set; }
    }
}
