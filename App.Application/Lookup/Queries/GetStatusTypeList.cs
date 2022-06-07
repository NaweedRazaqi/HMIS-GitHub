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
    public class GetStatusTypeList : IRequest<List<StatusTypeModel>>
    {
        public int ID { get; set; }
    }
    public class GetStatusTypeListHandler : IRequestHandler<GetStatusTypeList, List<StatusTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetStatusTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<StatusTypeModel>> Handle(GetStatusTypeList request, CancellationToken cancellationToken)
        {
            var query = Context.StatusTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new StatusTypeModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
