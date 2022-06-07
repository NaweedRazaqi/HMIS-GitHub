using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class SelectQueue
    {
        public long Id { get; set; }
        public int CandidateId { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? SelectedOn { get; set; }
        public int? CurrentYearsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int? GenderId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
