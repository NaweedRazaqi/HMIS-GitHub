using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class Commitee
    {
        public Commitee()
        {
            CommiteeMember = new HashSet<CommiteeMember>();
            Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public string Name { get; set; }
        public int CommiteeTypeId { get; set; }
        public DateTime Date { get; set; }

        public virtual CommiteeType CommiteeType { get; set; }
        public virtual ICollection<CommiteeMember> CommiteeMember { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
