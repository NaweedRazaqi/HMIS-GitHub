using App.Domain.Entity.look;
using System;
namespace App.Domain.Entity.prf
{
    public partial class Passport
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int PassportNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpairyDate { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public string NationalId { get; set; }
        public int? PassportTypeId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual PassportType PassportType { get; set; }
    }
}
