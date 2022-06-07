using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Organization
    {
        public Organization()
        {
            CommiteeMember = new HashSet<CommiteeMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dari { get; set; }
        public string Pashto { get; set; }
        public string Code { get; set; }
        public short StatusId { get; set; }
        public short OrganizationTypeId { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }

        public virtual ICollection<CommiteeMember> CommiteeMember { get; set; }
    }
}
