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
    public class GetAirLineList : IRequest<List<AirLineModel>>
    {
        public int ID { get; set; }
    }
    public class GetAirLineListHandler : IRequestHandler<GetAirLineList, List<AirLineModel>>
    {
        private AppDbContext Context { get; set; }
        public GetAirLineListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<AirLineModel>> Handle(GetAirLineList request, CancellationToken cancellationToken)
        {
            var query = Context.Airlines.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new AirLineModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
