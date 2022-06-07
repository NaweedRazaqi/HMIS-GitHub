using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
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
