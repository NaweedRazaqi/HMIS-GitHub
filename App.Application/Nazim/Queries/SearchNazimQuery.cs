using App.Application.Nazim.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
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

namespace App.Application.Nazim.Queries
{
    public class SearchNazimQuery : IRequest<IEnumerable<SearchNazimModel>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string  GrandFatherName { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public int? YearId { get; set; }
        public int? CandidateId { get; set; }
        public int? CandidateTypeId { get; set; }
        public int? ArchiveNo { get; set; }
        public int UserID { get; set; }
        // public int? ArchiveNo { get; set; }
    }
    public class SearchNazimQueryHandler : IRequestHandler<SearchNazimQuery, IEnumerable<SearchNazimModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchNazimQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchNazimModel>> Handle(SearchNazimQuery request, CancellationToken cancellationToken)
        {
            var query = context.Candidates.AsQueryable();
            int userid = await User.GetUserId();
            var role = IDContext.UserRoles.Where(ur=> ur.UserId == userid).Single();
           
           
            if (role.RoleId ==3)
            {
                query = query.Where(c => c.CandidateTypeId == 2);
            }
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.LastName))
            {
                query = query.Where(e => e.LastName == request.LastName);
            }
            if (!String.IsNullOrEmpty(request.FatherName))
            {
                query = query.Where(e => e.FatherName == request.FatherName);
            }
            if (!String.IsNullOrEmpty(request.GrandFatherName))
            {
                query = query.Where(e => e.GrandFatherName == request.GrandFatherName);
            }
           
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.Id == request.CandidateId);
            }
            if (request.CandidateTypeId != null)
            {
                query = query.Where(e => e.CandidateTypeId == 2);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => context.HajjYears.Where(H => H.CandidateId == request.CandidateId).Select(H => H.YearId).Single() == request.CandidateId);
            }
            return await query.Select(p => new SearchNazimModel
            {
                Id = p.Id,
                Code = p.Code,
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
                age = (Convert.ToInt32( DateTime.Now.Year) -Convert.ToInt32 (p.BirthDate.Year)).ToString() + " ساله  " ,
                ReligionId = p.ReligionId,
                EnrollmentDate =PersianDate.GetFormatedString(p.CreatedOn),
                BloodGroupId = p.BloodGroupId,
                IsInGroup = p.IsInGroup,
                //HajjProcessId=p.HajjProcessId,
                //SpecialEntityId = p.SpecialEntityId,
                MahramId = p.MahramId,
                Mahram=p.Mahram.FirstName,
                RMahram=p.Relationship.Name,
                LanguageId=p.LanguageId,
                RelationshipId = p.RelationshipId,
                CandidateTypeId = p.CandidateTypeId,
                NazamCategoryId = p.NazamCategoryId,
                Remarks = p.Remarks,
                PhotoPath = p.PhotoPath,
                IsSelected = ( p.IsSelected == false  ? "نخیر"  : "بلی"),
                IsCanceledName = context.CancelCandidates.Where(c => c.CandidateId == p.Id).SingleOrDefault() != null ? "بلی" : "نخیر",
                GenderName = p.Gender.Name,
                PhoneNumber=p.Address.Phone,
                PhoneNumber2=p.Address.Mobile,
                ProvinceName=p.Address.Cprovince.Dari,
                DestrictName = p.Address.Cdistrict.Dari,
                Vilage=p.Address.CfullAdd,
                //JobTitle=p.Job.Where(j=>j.JobTitle==j.JobTitle).ToString(),
                ReligionName = p.Religion.Name,
                CandidateTypeName = p.CandidateType.Dari,
                CandidateId = p.Id,
                ArchiveNo=p.ArchiveNo,
                NID = p.NationalId,
                DocumentTypeId = p.DocumentTypeId,
                DocumentTypeText = p.DocumentType.Name,
                NIDText = NationalIDReader.ConvertJSONToString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
                TazkiraNumber = NationalIDReader.ConvertJSONToShortString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
                YearId = context.HajjYears.Where(H => H.CandidateId == request.CandidateId).Select(H => H.Year.Id).Single(),
                YearName = ( request.Flag == "Cancel"  ? context.HajjYears.Where(H => H.CandidateId == request.CandidateId).Select(H => H.Year.Name).SingleOrDefault() : 0 ),

        }).ToListAsync();

            
        }
    }
}
