using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Evcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ZoneId { get; set; }

        public virtual Evzone Zone { get; set; }
    }
}
