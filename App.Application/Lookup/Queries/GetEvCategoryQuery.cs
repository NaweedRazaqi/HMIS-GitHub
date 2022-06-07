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
   public class GetEvCategoryQuery : IRequest<List<EeCategoryModel>>
    {
        public int? Id { get; set; }
    }
    public class GetEvCategoryQueryHandler : IRequestHandler<GetEvCategoryQuery, List<EeCategoryModel>>
    {
        private AppDbContext Context { get; set; }
        public GetEvCategoryQueryHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<EeCategoryModel>> Handle(GetEvCategoryQuery request, CancellationToken cancellationToken)
        {
            List<EeCategoryModel> list = new List<EeCategoryModel>();

            var query = Context.Evcategories.AsQueryable();
            if (request.Id != null)
            {
                query = query.Where(c => c.Id == request.Id);
            }

            list = await (from c in query
                          select new EeCategoryModel
                          {
                              Id = c.Id,
                              ZoneId= c.ZoneId,
                              Name = c.Name,
                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
