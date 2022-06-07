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
    public class GetRelationList : IRequest<List<RelationModel>>
    {
        public int ID { get; set; }
    }
    public class GetRelationListHandler : IRequestHandler<GetRelationList, List<RelationModel>>
    {
        private AppDbContext Context { get; set; }
        public GetRelationListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<RelationModel>> Handle(GetRelationList request, CancellationToken cancellationToken)
        {
            var query = Context.Relations.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new RelationModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
