using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class SearchJobQuery : IRequest<IEnumerable<SearchJobModel>>
    {
        public int? Id { get; set; }
        public int? CandidateId { get; set; }
        public int? OrganizationId { get; set; }
    }
    public class SearchJobQueryHandler : IRequestHandler<SearchJobQuery, IEnumerable<SearchJobModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchJobQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchJobModel>> Handle(SearchJobQuery request, CancellationToken cancellationToken)
        {
            var query = context.Jobs.AsQueryable();
            
            if (request.Id.HasValue)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId.HasValue)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.OrganizationId.HasValue)
            {
                query = query.Where(e => e.OrganizationId == request.OrganizationId);
            }
            
            return await query.Select(p => new SearchJobModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                OrganizationId = p.OrganizationId,
                OrganizationName = p.Organization.Dari,
                JobTilteId = p.JobTilteId,
                JobType=p.JobTilte.Dari,
                ProvinceId = p.ProvinceId,
                RankId = p.RankId,
                DistrictId = p.DistrictId,
                JobTitleText = p.JobTitleText,
                ProviceText = p.Province.Dari,
                DistrictText = p.District.Dari

            }).ToListAsync();
        }
    }
}
