using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class CommiteeMember
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public int GenderId { get; set; }
        public int CommiteeId { get; set; }
        public int OrganizationId { get; set; }

        public virtual Commitee Commitee { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
