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
    public class GetRelativeList : IRequest<List<RelativeModel>>
    {
        public int ID { get; set; }
    }
    public class GetRelativeListHandler : IRequestHandler<GetRelativeList, List<RelativeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetRelativeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<RelativeModel>> Handle(GetRelativeList request, CancellationToken cancellationToken)
        {
            var query = Context.Relatives.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new RelativeModel
            {
                ID = e.Id,
                FullName = e.FirstName + " " + e.LastName + " ولد " + e.FatherName,
            }).ToListAsync();
        }
    }
}
