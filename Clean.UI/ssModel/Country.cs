using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Country
    {
        public Country()
        {
            Office = new HashSet<Office>();
        }

        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Office> Office { get; set; }
    }
}
