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
    public class GetHajStatusList : IRequest<List<HajStatusModel>>
    {
        public int? ID { get; set; }
    }

    public class GetHajStatusListHandler : IRequestHandler<GetHajStatusList, List<HajStatusModel>>
    {
        private AppDbContext Context { get; set; }
        public GetHajStatusListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<HajStatusModel>> Handle(GetHajStatusList request, CancellationToken cancellationToken)
        {
            var query = Context.HajiStatuses.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new HajStatusModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
