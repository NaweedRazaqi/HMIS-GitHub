using System;
using System.Collections.Generic;

namespace Clean.UI.model
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
