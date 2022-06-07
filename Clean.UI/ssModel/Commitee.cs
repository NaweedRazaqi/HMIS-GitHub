using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
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
        public string ModifiedBy { get; set; }
        public string Name { get; set; }
        public int CommiteeTypeId { get; set; }
        public DateTime Date { get; set; }
        public int? CreatedBy { get; set; }

        public virtual CommiteeType CommiteeType { get; set; }
        public virtual ICollection<CommiteeMember> CommiteeMember { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
    }
}
