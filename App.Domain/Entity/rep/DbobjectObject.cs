using System;
using System.Collections.Generic;

namespace App.Domain.Entity.rep { 
    public partial class DbobjectObject
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long? ChildId { get; set; }

        public virtual Dbobject Parent { get; set; }
        public virtual Dbobject Child { get; set; }

    }
}
