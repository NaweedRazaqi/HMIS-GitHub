using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class SearchNazamAssignmentQuery : IRequest<IEnumerable<SearchNazamAssignmentModel>>
    {
        public int Id { get; set; }
        public int? NazamCandidateId { get; set; }
        public int? CandidateTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
    }
    public class SearchNazamAssignmentQueryHandler : IRequestHandler<SearchNazamAssignmentQuery, IEnumerable<SearchNazamAssignmentModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchNazamAssignmentQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchNazamAssignmentModel>> Handle(SearchNazamAssignmentQuery request, CancellationToken cancellationToken)
        {
            var query = context.Candidates.AsQueryable();
            var Check = context.Candidates.Where(C => C.NazamCandidateId == request.Id).Count();
            if (request.NazamCandidateId != null)
            {
                query = query.Where(e => e.NazamCandidateId == request.NazamCandidateId);
            }
            if (request.Id != 0 && Check > 0)
            {
                query = query.Where(e => e.NazamCandidateId == request.Id);
            }
            if(Check <= 0)
            {
                query = query.Where(e => e.NazamCandidateId == null);
            }
            if (!String.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(e => e.FirstName == request.FirstName);
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
            if (!String.IsNullOrEmpty(request.Code))
            {
                query = query.Where(e => e.Code == request.Code);
            }
            if (request.CandidateTypeId != null)
            {
                query = query.Where(e => e.CandidateTypeId == request.CandidateTypeId);
            }
            return await query.Select(p => new SearchNazamAssignmentModel
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
                ReligionId = p.ReligionId,
                BloodGroupId = p.BloodGroupId,
                IsInGroup = p.IsInGroup,
                MahramId = p.MahramId,
                RelationshipId = p.RelationshipId,
                CandidateTypeId = p.CandidateTypeId,
                NazamCategoryId = p.NazamCategoryId,
                Remarks = p.Remarks,
                PhotoPath = p.PhotoPath,
                IsSelected = (p.IsSelected == false ? "نخیر" : "بلی"),
                //IsCanceledName = (p.IsCanceled == false ? "نخیر" : "بلی"),
                //IsCanceled = (p.IsCanceled == true ? 1 : 0),
                GenderName = p.Gender.Name,
                ReligionName = p.Religion.Name,
                NazamCandidateId = p.NazamCandidateId,
                NazamCandidateStatus = p.NazamCandidateId == null ? "نخیر" : "بلی",
                CandidateTypeName = p.CandidateType.Dari,
            }).ToListAsync();
        }
    }
}
