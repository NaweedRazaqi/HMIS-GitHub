using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
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
    public class SearchCancelCandidateQuery : IRequest<IEnumerable<SearchCancelCandidateModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public DateTime? Date { get; set; }
    }
    public class SearchCancelCandidateQueryHandler : IRequestHandler<SearchCancelCandidateQuery, IEnumerable<SearchCancelCandidateModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchCancelCandidateQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchCancelCandidateModel>> Handle(SearchCancelCandidateQuery request, CancellationToken cancellationToken)
        {
            var query = context.CancelCandidates.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.Date != null)
            {
                query = query.Where(e => e.Date == request.Date);
            }
            return await query.Select(p => new SearchCancelCandidateModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                Date = p.Date,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                Remarks = p.Remarks,
                CancelReasons = p.CancelReasons,
            }).ToListAsync();
        }
    }
}
