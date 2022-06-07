using App.Application.Candidate.Models;
using App.Persistence.Context;
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
    public class SearchCandidateStatusQuery : IRequest<IEnumerable<SearchCandidateStatusModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? StatusTypeId { get; set; }
        public int? CprovincesId { get; set; }
    }
    public class SearchCandidateStatusQueryHandler : IRequestHandler<SearchCandidateStatusQuery, IEnumerable<SearchCandidateStatusModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchCandidateStatusQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchCandidateStatusModel>> Handle(SearchCandidateStatusQuery request, CancellationToken cancellationToken)
        {
            var query = context.CandidateStatuses.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.StatusTypeId != null)
            {
                query = query.Where(e => e.StatusTypeId == request.StatusTypeId);
            }
            if (request.CprovincesId != null)
            {
                query = query.Where(e => e.CprovincesId == request.CprovincesId);
            }
            return await query.Select(p => new SearchCandidateStatusModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                CprovincesId = p.CprovincesId,
                StatusTypeId = p.StatusTypeId,
                ProvinceName = p.Cprovinces.Dari,
                StatusTypeName = p.StatusType.Dari,
                RoomNo = p.RoomNo,
                Remarks = p.Remarks,
            }).ToListAsync();
        }
    }
}
