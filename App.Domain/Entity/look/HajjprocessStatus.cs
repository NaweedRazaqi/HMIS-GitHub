﻿using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class HajjprocessStatus
    {
        public HajjprocessStatus()
        {
            Candidate = new HashSet<Candidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
