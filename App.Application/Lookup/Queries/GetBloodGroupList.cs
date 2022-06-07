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
    public class GetBloodGroupList : IRequest<List<BloodGroupModel>>
    {
        public int ID { get; set; }
    }
    public class GetBloodGroupListHandler : IRequestHandler<GetBloodGroupList, List<BloodGroupModel>>
    {
        private AppDbContext Context { get; set; }
        public GetBloodGroupListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<BloodGroupModel>> Handle(GetBloodGroupList request, CancellationToken cancellationToken)
        {
            var query = Context.BloodGroups.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new BloodGroupModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
