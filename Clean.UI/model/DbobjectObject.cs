using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class DbobjectObject
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long? ChildId { get; set; }
    }
}
