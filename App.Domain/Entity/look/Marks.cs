using App.Domain.Entity.Evaluation;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.look
{
    public partial class Marks
    {
        public Marks()
        {
            Nerecords = new HashSet<Nerecords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Nerecords> Nerecords { get; set; }
    }
}
