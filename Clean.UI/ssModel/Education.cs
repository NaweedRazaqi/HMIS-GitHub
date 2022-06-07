using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Education
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? DegreeId { get; set; }
        public long? FieldofstudyId { get; set; }
        public int? CountryId { get; set; }
        public int? UniversityId { get; set; }
        public int? StudyTypeId { get; set; }
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
        public virtual University University { get; set; }
    }
}
