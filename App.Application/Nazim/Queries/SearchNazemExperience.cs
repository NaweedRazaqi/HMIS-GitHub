using App.Application.Nazim.Models;
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

namespace App.Application.Nazim.Queries
{

    public class SearchNazemExperience : IRequest<IEnumerable<SearchNazemExperienceModel>>
    {
        public int? Id { get; set; }
        public int? CandidateId { get; set; }
    }
    public class SearchNazemExperienceHandler : IRequestHandler<SearchNazemExperience, IEnumerable<SearchNazemExperienceModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchNazemExperienceHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }

        public async Task<IEnumerable<SearchNazemExperienceModel>> Handle(SearchNazemExperience request, CancellationToken cancellationToken)
        {
            var query = context.NazemExperiences.AsQueryable();

            if (request.Id.HasValue)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId.HasValue)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
         

            return await query.Select(p => new SearchNazemExperienceModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                PrevouseHajCount = p.PrevouseHajCount,
                YearId = p.YearId,
                ExpenseType = p.ExpenseType,
                Yearname = p.Year.Name,
                ExpenseTypeText = (p.ExpenseType == 1 ? "مصرف شخصی" : "از طرف وزارت حج و اوقاف")
            }).ToListAsync();
        }
    }
}