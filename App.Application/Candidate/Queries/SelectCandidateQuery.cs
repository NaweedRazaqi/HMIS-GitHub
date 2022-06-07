using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Exceptions;
using Clean.Common.Service;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class SelectCandidateQuery : IRequest<IEnumerable<SelectCandidateModel>>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public int? YearId { get; set; }
        public int? CandidateId { get; set; }
        public int? CandidateTypeId { get; set; }
        public int? ArchiveNo { get; set; }
        public int UserID { get; set; }
        public int? HajiStatusId { get; set; }
    }
    public class SelectCandidateQueryHandler : IRequestHandler<SelectCandidateQuery, IEnumerable<SelectCandidateModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SelectCandidateQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SelectCandidateModel>> Handle(SelectCandidateQuery request, CancellationToken cancellationToken)
        {
            var query = context.Candidates.AsQueryable();
            int userid = await User.GetUserId();
            var role = IDContext.UserRoles.Where(ur => ur.UserId == userid).Single();
            var yId = context.Years.Where(e => e.Id==request.YearId).Select(y=>y.Id).SingleOrDefault();
           
            int usedCap = context.Candidates.Where(ca => ca.YearId == yId).Count();
            if (role.RoleId == 1)
            {
                query = query.Where(c => c.CandidateTypeId == 1 || c.CandidateTypeId == 2);
            }
            if (request.HajiStatusId.HasValue)
            {
                query = query.Where(hs => hs.HajiStatusId == 2);
            }
            if (request.YearId!=0 & request.YearId==yId)
            {
                query = query.Where(ca => ca.YearId == yId);
            }
           
            return await query.Select(p => new SelectCandidateModel
            {
                Id = p.Id,
                Code = p.Code,
                HajiStatusId=p.HajiStatusId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FatherName = p.FatherName,
                GrandFatherName = p.GrandFatherName,
                FirstNameEnglish = p.FirstNameEnglish,
                LastNameEnglish = p.LastNameEnglish,
                FatherNameEnglish = p.FatherNameEnglish,
                GrandFatherNameEnglish = p.GrandFatherNameEnglish,
                GenderId = p.GenderId,
                MaritalStatusId = p.MaritalStatusId,
                BirthDate = p.BirthDate,
                age = (Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(p.BirthDate.Year)).ToString() + " ساله  ",
                ReligionId = p.ReligionId,
                EnrollmentDate = PersianDate.GetFormatedString(p.CreatedOn),
                BloodGroupId = p.BloodGroupId,
                IsInGroup = p.IsInGroup,
                //SpecialEntityId = p.SpecialEntityId,
                MahramId = p.MahramId,
                Mahram = p.Mahram.FirstName,
                RMahram = p.Relationship.Name,
                LanguageId = p.LanguageId,
                RelationshipId = p.RelationshipId,
                CandidateTypeId = p.CandidateTypeId,
                NazamCategoryId = p.NazamCategoryId,
                Remarks = p.Remarks,
                PhotoPath = p.PhotoPath,
                IsSelected = (p.IsSelected == false ? "نخیر" : "بلی"),
                IsCanceledName = context.CancelCandidates.Where(c => c.CandidateId == p.Id).SingleOrDefault() != null ? "بلی" : "نخیر",
                GenderName = p.Gender.Name,
                PhoneNumber = p.Address.Phone,
                PhoneNumber2 = p.Address.Mobile,
                ProvinceName = p.Address.Cprovince.Dari,
                DestrictName = p.Address.Cdistrict.Dari,
                Vilage = p.Address.CfullAdd,
                //JobTitle = p.Job.Where(j => j.JobTitle == j.JobTitle).ToString(),
                ReligionName = p.Religion.Name,
                CandidateTypeName = p.CandidateType.Dari,
                CandidateId = p.Id,
                ArchiveNo = p.ArchiveNo,
                NID = p.NationalId,
                DocumentTypeId = p.DocumentTypeId,
                DocumentTypeText = p.DocumentType.Name,
                NIDText = NationalIDReader.ConvertJSONToString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
                TazkiraNumber = NationalIDReader.ConvertJSONToShortString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
                YearId = yId

            }).Take(20).ToListAsync();


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
