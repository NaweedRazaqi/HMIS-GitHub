using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Religion
    {
        public Religion()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
