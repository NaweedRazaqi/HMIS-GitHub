using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Language
    {
        public Language()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Local { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
