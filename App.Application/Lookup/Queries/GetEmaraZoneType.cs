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


    public class GetEmaraZoneType : IRequest<List<SearchEmaraTypeModel>>
    {
        public int ID { get; set; }
    }

    public class GetEmaraZoneTypeHandler : IRequestHandler<GetEmaraZoneType, List<SearchEmaraTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetEmaraZoneTypeHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<SearchEmaraTypeModel>> Handle(GetEmaraZoneType request, CancellationToken cancellationToken)
        {
            var query = Context.EmaraZoneTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new SearchEmaraTypeModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}