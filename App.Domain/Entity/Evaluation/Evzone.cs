using System;
using System.Collections.Generic;

namespace App.Domain.Entity.Evaluation
{
    public partial class Evzone
    {
        public Evzone()
        {
            Evcategory = new HashSet<Evcategory>();
            Nerecords = new HashSet<Nerecords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Evcategory> Evcategory { get; set; }
        public virtual ICollection<Nerecords> Nerecords { get; set; }
    }
}
