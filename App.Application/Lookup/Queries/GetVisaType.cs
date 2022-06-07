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


    public class GetVisaType : IRequest<List<VisaTypeModel>>
    {
        public int? ID { get; set; }
    }


    public class GetVisaTypeHandler : IRequestHandler<GetVisaType, List<VisaTypeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetVisaTypeHandler(AppDbContext context)
        {
            Context = context;
        }


        public async Task<List<VisaTypeModel>> Handle(GetVisaType request, CancellationToken cancellationToken)
        {
           var query = Context.VisaType.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new VisaTypeModel
            {
                Id = e.Id,
                Name = e.Name,
            }).ToListAsync();
        }
    }
}