using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.Persistence.Context;
using App.Application.Report.Models;

namespace App.Application.Report.Queries
{
    public class SearchDBObjectObjectQuery : IRequest<List<SearchDBObjectObjectModel>>
    {
        public int? ParentID { get; set; }
    }

    public class SearchDBObjectObjectQueryHandler : IRequestHandler<SearchDBObjectObjectQuery, List<SearchDBObjectObjectModel>>
    {
        private readonly AppDbContext context;
        public SearchDBObjectObjectQueryHandler(AppDbContext dbContext)
        {
            context = dbContext;
        }
        public async Task<List<SearchDBObjectObjectModel>> Handle(SearchDBObjectObjectQuery request, CancellationToken cancellationToken)
        {
            var query = context.DbobjectObject.AsQueryable();
            if (request.ParentID.HasValue)
            {
                
                query = query.Where(c => c.ParentId==request.ParentID);
            }
            return await query.Include(e => e.Child).Include(e => e.Parent)
                                .Select(e => new SearchDBObjectObjectModel
                                {
                                    ID = e.Id,
                                    ParentID = e.ParentId,
                                    ChildID = e.ChildId,
                                    ParentText = e.Parent.DisplayName,
                                    ChildText = e.Child.DisplayName
                                }).ToListAsync();
            
        }
    }
}
