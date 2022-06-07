using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Service;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class SearchRelativeQuery : IRequest<IEnumerable<SearchRelativeModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? ProvincesId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
    }
    public class SearchRelativeQueryHandler : IRequestHandler<SearchRelativeQuery, IEnumerable<SearchRelativeModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchRelativeQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchRelativeModel>> Handle(SearchRelativeQuery request, CancellationToken cancellationToken)
        {
            var query = context.Relatives.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.ProvincesId != null)
            {
                query = query.Where(e => e.ProvincesId == request.ProvincesId);
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
            return await query.Select(p => new SearchRelativeModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                ProvincesId = p.ProvincesId,
                ProvincesName = p.Provinces.Dari,
                DistrictId = p.DistrictId,
                DistrictName = p.District.Dari,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FatherName = p.FatherName,
                GrandFatherName = p.GrandFatherName,
                FullAddress = p.FullAddress,
                GenderId = p.GenderId,
                RelationshipId = p.RelationshipId,
                GenderName = p.Gender.Name,
                RelationshipName = p.Relationship.Name,
                Mobile = p.Mobile,
                Phone = p.Phone,
                Remarks = p.Remarks,
                DocumentTypeId = p.DocumentTypeId,
                DocumentTypeText = p.DocumentType.Name,
                NID = p.NationalId,
                
                NIDText = NationalIDReader.ConvertJSONToString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
                TazkiraNumber = NationalIDReader.ConvertJSONToShortString(p.NationalId, p.DocumentType.Name) ?? "درج نگردیده",
            }).ToListAsync();
        }
    }
}
