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
    public class GetEmaraType : IRequest<List<SearchEmaraTypeModel>>
    {
        public int Id { get; set; }
    }

    public class GetEmaraTypeHandler : IRequestHandler<GetEmaraType, List<SearchEmaraTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetEmaraTypeHandler(AppDbContext context)
        {
            Context = context;
        }



        public async Task<List<SearchEmaraTypeModel>> Handle(GetEmaraType request, CancellationToken cancellationToken)
        {
            var query = Context.EmaraTypes.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }

            return await query.Select(e => new SearchEmaraTypeModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
    