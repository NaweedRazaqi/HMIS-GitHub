using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
