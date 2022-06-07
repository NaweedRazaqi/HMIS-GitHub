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
    public class GetMutamidList : IRequest<List<MutamidModel>>
    {
        public int ID { get; set; }
    }
    public class GetMutamidListHandler : IRequestHandler<GetMutamidList, List<MutamidModel>>
    {
        private AppDbContext Context { get; set; }
        public GetMutamidListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<MutamidModel>> Handle(GetMutamidList request, CancellationToken cancellationToken)
        {
            var query = Context.Mutamids.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new MutamidModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
