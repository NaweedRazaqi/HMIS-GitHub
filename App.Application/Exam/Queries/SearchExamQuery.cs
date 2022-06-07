using App.Application.Exam.Models;
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

namespace App.Application.Exam.Queries
{
    public class SearchExamQuery : IRequest<IEnumerable<SearchExamModel>>
    {
        public int Id { get; set; }
        public int? CommiteeId { get; set; }
        public DateTime? Date { get; set; }
    }
    public class SearchExamQueryHandler : IRequestHandler<SearchExamQuery, IEnumerable<SearchExamModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchExamQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchExamModel>> Handle(SearchExamQuery request, CancellationToken cancellationToken)
        {
            var query = context.Exams.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.Date != null)
            {
                query = query.Where(e => e.Date == request.Date);
            }
            if (request.CommiteeId != null)
            {
                query = query.Where(e => e.CommiteeId == request.CommiteeId);
            }
            return await query.Select(p => new SearchExamModel
            {
                Id = p.Id,
                Date = p.Date,
                CommiteeId = p.CommiteeId,
                CommiteeName = p.Commitee.Name,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
            }).ToListAsync();
        }
    }
}
