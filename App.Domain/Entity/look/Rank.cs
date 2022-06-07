using App.Domain.Entity.prf;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entity.look
{
   public  class Rank
    {

        public Rank()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public char? Type { get; set; }
        public int StatusId { get; set; }
        public short? Sorter { get; set; }
        public short? CategoryId { get; set; }
        public int? Rate { get; set; }

        public virtual ICollection<Job> Job { get; set; }
    }
}
