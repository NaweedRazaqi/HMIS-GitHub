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
    public class GetMosqueList : IRequest<List<MosqueModel>>
    {
        public int ID { get; set; }
    }
    public class GetMosqueListHandler : IRequestHandler<GetMosqueList, List<MosqueModel>>
    {
        private AppDbContext Context { get; set; }
        public GetMosqueListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<MosqueModel>> Handle(GetMosqueList request, CancellationToken cancellationToken)
        {
            var query = Context.Mosques.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new MosqueModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
