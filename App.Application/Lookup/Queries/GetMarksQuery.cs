using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
   public class GetMarksQuery : IRequest<List<MarksModel>>
    {
        public int? Id { get; set; }
    }
    public class GetMarksQueryHandler : IRequestHandler<GetMarksQuery, List<MarksModel>>
    {
        private AppDbContext Context { get; set; }
        public GetMarksQueryHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<MarksModel>> Handle(GetMarksQuery request, CancellationToken cancellationToken)
        {
            List<MarksModel> list = new List<MarksModel>();

            var query = Context.Marks.AsQueryable();
            if (request.Id != null)
            {
                query = query.Where(c => c.Id == request.Id);
            }
            list = await (from c in query
                          select new MarksModel
                          {
                              Id = c.Id,
                              Name = c.Name,
                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
