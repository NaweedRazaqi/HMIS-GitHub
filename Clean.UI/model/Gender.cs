using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Gender
    {
        public Gender()
        {
            Candidate = new HashSet<Candidate>();
            CommiteeMember = new HashSet<CommiteeMember>();
            Relative = new HashSet<Relative>();
            Sscandidate = new HashSet<Sscandidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<CommiteeMember> CommiteeMember { get; set; }
        public virtual ICollection<Relative> Relative { get; set; }
        public virtual ICollection<Sscandidate> Sscandidate { get; set; }
    }
}
