using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Dbobject
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Dbname { get; set; }
        public string Pkey { get; set; }
        public string Fkey { get; set; }
        public string Title { get; set; }
        public long? Type { get; set; }
    }
}
