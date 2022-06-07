using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class HajiStatus
    {
        public HajiStatus()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
