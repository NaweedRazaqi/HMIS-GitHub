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
    public class GetPassportTypeList : IRequest<List<PassportTypeModel>>
    {
        public int? ID { get; set; }
    }

    public class GetPassportTypeListHandler : IRequestHandler<GetPassportTypeList, List<PassportTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetPassportTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<PassportTypeModel>> Handle(GetPassportTypeList request, CancellationToken cancellationToken)
        {
            var query = Context.PassportTypes.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new PassportTypeModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
