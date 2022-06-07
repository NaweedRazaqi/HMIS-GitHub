using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Education1
    {
        public int Degreeid { get; set; }
        public string University { get; set; }
        public long? Fieldofstudyid { get; set; }
        public int? Countryid { get; set; }
        public int Id { get; set; }
        public int? Candidateid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location Country { get; set; }
        public virtual EducationDegree Degree { get; set; }
        public virtual FieldofStudy Fieldofstudy { get; set; }
    }
}
