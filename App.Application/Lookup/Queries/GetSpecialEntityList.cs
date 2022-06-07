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
    public class GetSpecialEntityList : IRequest<List<SpecialEntityModel>>
    {
        public int ID { get; set; }
    }
    public class GetSpecialEntityListHandler : IRequestHandler<GetSpecialEntityList, List<SpecialEntityModel>>
    {
        private AppDbContext Context { get; set; }
        public GetSpecialEntityListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<SpecialEntityModel>> Handle(GetSpecialEntityList request, CancellationToken cancellationToken)
        {
            var query = Context.SpecialEntities.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new SpecialEntityModel
            {
                ID = e.Id,
                OrderNo = e.OrderNumber
            }).ToListAsync();
        }
    }
}
