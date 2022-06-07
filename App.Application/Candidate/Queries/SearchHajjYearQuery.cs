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
    public class SearchHajjYearQuery : IRequest<IEnumerable<SearchHajjYearModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? YearId { get; set; }
        public int? ProvincesId { get; set; }
    }
    public class SearchHajjYearQueryHandler : IRequestHandler<SearchHajjYearQuery, IEnumerable<SearchHajjYearModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchHajjYearQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchHajjYearModel>> Handle(SearchHajjYearQuery request, CancellationToken cancellationToken)
        {
            var query = context.HajjYears.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.ProvincesId != null)
            {
                query = query.Where(e => e.ProvincesId == request.ProvincesId);
            }
            return await query.Select(p => new SearchHajjYearModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                ProvincesId = p.ProvincesId,
                ProvincesName = p.Provinces.Dari,
                YearId = p.YearId,
                YearName = p.Year.Name,
                EnrollmentId = p.EnrollmentId,
                ArchiveNo = p.ArchiveNo,
                //IsCanceled = context.HajjYears.Where(c => c.CandidateId == p.Id).SingleOrDefault() != null ? "بلی" : "نخیر"
            }).ToListAsync();
        }
    }
}
