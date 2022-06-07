using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class VCandidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public int? GenderId { get; set; }
    }
}
