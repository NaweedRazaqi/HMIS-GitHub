using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
   public class GetZoneQuery : IRequest<List<ZoneModel>>
    {
        public int? Id { get; set; }
    }
    public class GetZoneQueryHandler : IRequestHandler<GetZoneQuery, List<ZoneModel>>
    {
        private AppDbContext Context { get; set; }
        public GetZoneQueryHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<ZoneModel>> Handle(GetZoneQuery request, CancellationToken cancellationToken)
        {
            List<ZoneModel> list = new List<ZoneModel>();

            var query = Context.Evzones.AsQueryable();
            if (request.Id != null)
            {
                query = query.Where(o => o.Id == request.Id);
            }

            list = await (from o in query
                          select new ZoneModel
                          {
                              Id = o.Id,
                              Name = o.Name,

                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
