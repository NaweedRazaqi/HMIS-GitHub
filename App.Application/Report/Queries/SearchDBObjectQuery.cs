using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entity.rep;
using App.Persistence.Context;

namespace App.Application.Report.Queries
{
    public class SearchDBObjectQuery : IRequest<List<Dbobject>>
    {
        public int? Type { get; set; }
        public int? ID { get; set; }
    }

    public class SearchDBObjectQueryHandler : IRequestHandler<SearchDBObjectQuery, List<Dbobject>>
    {
        private readonly AppDbContext context;
        public SearchDBObjectQueryHandler(AppDbContext dbContext)
        {
            context = dbContext;
            
        }
        public async Task<List<Dbobject>> Handle(SearchDBObjectQuery request, CancellationToken cancellationToken)
        {
            var query = context.Dbobject.AsQueryable();
            if (request.Type.HasValue)
            {
                query = query.Where(c=>c.Type==request.Type);
            }

            if (request.ID.HasValue)
            {
                query = query.Where(c => c.Id==request.ID);
            }
            return await query.ToListAsync();
        }
    }
}
