using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class CommiteeType
    {
        public CommiteeType()
        {
            Commitee = new HashSet<Commitee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Commitee> Commitee { get; set; }
    }
}
