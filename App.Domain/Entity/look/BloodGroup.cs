﻿using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entity.look
{
    public class BloodGroup
    {
        public BloodGroup()
        {
            Candidate = new HashSet<Candidate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
