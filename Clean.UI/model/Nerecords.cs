using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Nerecords
    {
        public int Id { get; set; }
        public int? Nid { get; set; }
        public int? Evid { get; set; }
        public int? MarkId { get; set; }
        public int? ZoneId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Evcategory Ev { get; set; }
        public virtual Marks Mark { get; set; }
        public virtual Candidate N { get; set; }
        public virtual Evzone Zone { get; set; }
    }
}
