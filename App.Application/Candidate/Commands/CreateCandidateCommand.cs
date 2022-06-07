using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Exceptions;
using Clean.Common.Extensions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateCandidateCommand : IRequest<List<SearchCandidateModel>>
    {
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
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public DateTime BirthDate { get; set; }
        public int ReligionId { get; set; }
        public int BloodGroupId { get; set; }
        public int IsInGroup { get; set; }
        //public int? SpecialEntityId { get; set; }
        public int? MahramId { get; set; }
        public int? RelationshipId { get; set; }
        public int CandidateTypeId { get; set; }
        public int? NazamCategoryId { get; set; }
        public string Remarks { get; set; }
        public bool IsSelected { get; set; }
        //public bool IsCanceled { get; set; }
        public string PhotoPath { get; set; }
        public int? LanguageId { get; set; }
        public int ArchiveNo { get; set; }
        public int? DocumentTypeId { get; set; }
        public string NID { get; set; }
        public int? YearId { get; set; }
        public int? HajiStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? IsEmployed { get; set; }
    }
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, List<SearchCandidateModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateCandidateCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchCandidateModel>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Candidate = request.Id != 0 ? context.Candidates.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Candidate();
            IEnumerable<SearchCandidateModel> result = new List<SearchCandidateModel>();
            bool ismployed = false;
            var enYear = PersianToEnglish(PersianDate.ToPersianDate(DateTime.Now).Substring(0, 4));
            var yearId = 0;
            var yId = context.Years.Where(e => e.Name.ToString() == enYear).Select(e=> e.Id).SingleOrDefault();

            int usedCap = context.Candidates.Where(ca => ca.YearId == yId).Count();
            var cYearCap = context.HajyearlyCapacities.Where(c => c.YearId == yId).Select(e=> e.TotalCapacity).SingleOrDefault();
            var pcYearCap = context.ProvincesCapacities.Where(c => c.YearId == yId).Select(e=> e.ProvinceCapacity).SingleOrDefault();
            if(request.IsEmployed == 0)
            {
                ismployed = false;
            }
            else
            {
                ismployed = true;
            }
            if (usedCap < cYearCap)
            {
                yearId = yId;
            }
            else
            {
                yearId = context.Years.Where(e => e.Name.ToString() == (Convert.ToInt32(enYear) + 1).ToString() ).Select(e => e.Id).SingleOrDefault();
            }

            /*
            var Duplicate = context.Candidates.Where(C => C.FirstName == request.FirstName
                && C.LastName == request.LastName
                && C.FatherName == request.FatherName
                && C.GrandFatherName == request.GrandFatherName
                && C.CandidateTypeId == request.CandidateTypeId
                && C.NationalId == request.NID).Count();
                if (Duplicate > 0 )
                {
                    throw new BusinessRulesException(" قبلا  ثبت گردیده است. ");
                }
                if (Duplicate <= 0)
               */
                //{
                    Candidate.FirstName = request.FirstName;
                    Candidate.LastName = request.LastName;
                    Candidate.FatherName = request.FatherName;
                    Candidate.GrandFatherName = request.GrandFatherName;
                    Candidate.FirstNameEnglish = request.FirstNameEnglish;
                    Candidate.LastNameEnglish = request.LastNameEnglish;
                    Candidate.FatherNameEnglish = request.FatherNameEnglish;
                    Candidate.GrandFatherNameEnglish = request.GrandFatherNameEnglish;
                    Candidate.GenderId = request.GenderId;
                    Candidate.MaritalStatusId = request.MaritalStatusId;
                    Candidate.BirthDate = request.BirthDate;
                    Candidate.ReligionId = request.ReligionId;
                    Candidate.BloodGroupId = request.BloodGroupId;
                    Candidate.IsInGroup = request.IsInGroup;
                    Candidate.MahramId = request.MahramId;
                    Candidate.RelationshipId = request.RelationshipId;
                    Candidate.CandidateTypeId = request.CandidateTypeId;
                    Candidate.NazamCategoryId = request.NazamCategoryId;
                    Candidate.Remarks = request.Remarks;
                    Candidate.PhotoPath = request.PhotoPath;
                    Candidate.ArchiveNo = request.ArchiveNo;
                    Candidate.LanguageId = request.LanguageId;
                    Candidate.DocumentTypeId = request.DocumentTypeId;
                    Candidate.NationalId = request.NID;
                    Candidate.IsSelected = false;
                    Candidate.HajiStatusId = 1;
                    Candidate.YearId = yearId;
                   Candidate.IsEmployed = ismployed;
                
              


                if (request.Id == 0)
                    {

                        StringBuilder PrefixBuilder = new StringBuilder(string.Empty);
                        StringBuilder HrCodeBuilder = new StringBuilder(string.Empty);

                        PrefixBuilder.Append("h");
                        PrefixBuilder.Append(("00" + request.CandidateTypeId.ToString()).Right(2));
                        PrefixBuilder.Append(("00" + Convert.ToDateTime(request.BirthDate).Year.ToString()).Right(2));
                        PrefixBuilder.Append(("00" + Convert.ToDateTime(request.BirthDate).Month.ToString()).Right(2));

                        int? Suffix;
                        var last = context.Candidates.Where(p => p.Prefix == PrefixBuilder.ToString()).OrderByDescending(e => e.Suffix).FirstOrDefault();
                        int? CurrentSuffix = last == null ? 0 : last.Suffix;
                        if (CurrentSuffix is null) CurrentSuffix = 0;
                        Suffix = CurrentSuffix + 1;

                        HrCodeBuilder.Append(PrefixBuilder.ToString());
                        HrCodeBuilder.Append(("000" + Suffix.ToString()).Right(3));

                        Candidate.Code = HrCodeBuilder.ToString();
                        Candidate.Prefix = PrefixBuilder.ToString();
                        Candidate.Suffix = Suffix;

                        Candidate.ModifiedBy = "";
                        Candidate.ModifiedOn = DateTime.Now;
                        Candidate.CreatedBy = CurrentUserId;
                        Candidate.CreatedOn = DateTime.Now;

                        try
                        {

                        context.Candidates.Add(Candidate);
                        }
                        catch(Exception e)
                        {
                            var s = e;
                        }
                //}
                }
            else
            {
                Candidate.ModifiedBy += "," + CurrentUserId; ;
                Candidate.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchCandidateQuery() { Id = Candidate.Id });
            return result.ToList();
        }

        private string[] persion = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private string[] english = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string PersianToEnglish(string strNum)
        {
            string chash = strNum;
            for (int i = 0; i < 10; i++)
                chash = chash.Replace(persion[i], english[i]);
            return chash;
        }

    }
}
