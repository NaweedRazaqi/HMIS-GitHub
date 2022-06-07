using System;
using System.Collections.Generic;

namespace Clean.UI.ssModel
{
    public partial class Relative
    {
        public Relative()
        {
            MoneyBack = new HashSet<MoneyBack>();
            ReturnMoney = new HashSet<ReturnMoney>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public int ProvincesId { get; set; }
        public int RelationshipId { get; set; }
        public int GenderId { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public int DistrictId { get; set; }
        public string NationalId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string FullAddress { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Location District { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Location Provinces { get; set; }
        public virtual Relation Relationship { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
        public virtual ICollection<ReturnMoney> ReturnMoney { get; set; }
    }
}
