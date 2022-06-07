using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class MaritalStatus
    {
        public MaritalStatus()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
