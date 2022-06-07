using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Relation
    {
        public Relation()
        {
            Candidate = new HashSet<Candidate>();
            Relative = new HashSet<Relative>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<Relative> Relative { get; set; }
    }
}
