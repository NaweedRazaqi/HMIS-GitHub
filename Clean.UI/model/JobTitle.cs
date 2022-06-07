using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            JobJobTilte = new HashSet<Job>();
            JobOrganization = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Dari { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }

        public virtual ICollection<Job> JobJobTilte { get; set; }
        public virtual ICollection<Job> JobOrganization { get; set; }
    }
}
