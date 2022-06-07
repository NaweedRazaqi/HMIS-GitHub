using System;
using System.Collections.Generic;

namespace Clean.UI.model
{
    public partial class Candidate
    {
        public Candidate()
        {
            ApproveInstallments = new HashSet<ApproveInstallments>();
            Attendence = new HashSet<Attendence>();
            CancelCandidate = new HashSet<CancelCandidate>();
            CandidateStatus = new HashSet<CandidateStatus>();
            Education1 = new HashSet<Education1>();
            Emara = new HashSet<Emara>();
            ExamScore = new HashSet<ExamScore>();
            HajjYear = new HashSet<HajjYear>();
            Installment = new HashSet<Installment>();
            InverseMahram = new HashSet<Candidate>();
            InverseNazamCandidate = new HashSet<Candidate>();
            Job = new HashSet<Job>();
            MoneyBack = new HashSet<MoneyBack>();
            NazamAssignmentCandidate = new HashSet<NazamAssignment>();
            NazamAssignmentNazamCandidate = new HashSet<NazamAssignment>();
            NazamSalary = new HashSet<NazamSalary>();
            NazamToMosque = new HashSet<NazamToMosque>();
            Nerecords = new HashSet<Nerecords>();
            ReturnMoney = new HashSet<ReturnMoney>();
            SelectQueue = new HashSet<SelectQueue>();
            SpecialEntity = new HashSet<SpecialEntity>();
            Sscandidate = new HashSet<Sscandidate>();
            TicketInfo = new HashSet<TicketInfo>();
            VisaInfo = new HashSet<VisaInfo>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FirstNameEnglish { get; set; }
        public string LastNameEnglish { get; set; }
        public string FatherNameEnglish { get; set; }
        public string GrandFatherNameEnglish { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? ReligionId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? IsInGroup { get; set; }
        public int? MahramId { get; set; }
        public int? RelationshipId { get; set; }
        public int? CandidateTypeId { get; set; }
        public int? NazamCategoryId { get; set; }
        public string Remarks { get; set; }
        public bool? IsSelected { get; set; }
        public string PhotoPath { get; set; }
        public string Prefix { get; set; }
        public int? Suffix { get; set; }
        public int? NazamCandidateId { get; set; }
        public int? HajiStatusId { get; set; }
        public int? LanguageId { get; set; }
        public int? ArchiveNo { get; set; }
        public string NationalId { get; set; }
        public int? DocumentTypeId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int? YearId { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual CandidateTypes CandidateType { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual HajiStatus HajiStatus { get; set; }
        public virtual HajjprocessStatus HajiStatusNavigation { get; set; }
        public virtual Language Language { get; set; }
        public virtual Candidate Mahram { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Candidate NazamCandidate { get; set; }
        public virtual Relation Relationship { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual Address Address { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Relative Relative { get; set; }
        public virtual ICollection<ApproveInstallments> ApproveInstallments { get; set; }
        public virtual ICollection<Attendence> Attendence { get; set; }
        public virtual ICollection<CancelCandidate> CancelCandidate { get; set; }
        public virtual ICollection<CandidateStatus> CandidateStatus { get; set; }
        public virtual ICollection<Education1> Education1 { get; set; }
        public virtual ICollection<Emara> Emara { get; set; }
        public virtual ICollection<ExamScore> ExamScore { get; set; }
        public virtual ICollection<HajjYear> HajjYear { get; set; }
        public virtual ICollection<Installment> Installment { get; set; }
        public virtual ICollection<Candidate> InverseMahram { get; set; }
        public virtual ICollection<Candidate> InverseNazamCandidate { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<MoneyBack> MoneyBack { get; set; }
        public virtual ICollection<NazamAssignment> NazamAssignmentCandidate { get; set; }
        public virtual ICollection<NazamAssignment> NazamAssignmentNazamCandidate { get; set; }
        public virtual ICollection<NazamSalary> NazamSalary { get; set; }
        public virtual ICollection<NazamToMosque> NazamToMosque { get; set; }
        public virtual ICollection<Nerecords> Nerecords { get; set; }
        public virtual ICollection<ReturnMoney> ReturnMoney { get; set; }
        public virtual ICollection<SelectQueue> SelectQueue { get; set; }
        public virtual ICollection<SpecialEntity> SpecialEntity { get; set; }
        public virtual ICollection<Sscandidate> Sscandidate { get; set; }
        public virtual ICollection<TicketInfo> TicketInfo { get; set; }
        public virtual ICollection<VisaInfo> VisaInfo { get; set; }
    }
}
