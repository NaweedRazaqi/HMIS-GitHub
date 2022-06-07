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
    public class GetHajjYearList : IRequest<List<HajjYearModel>>
    {
        public int ID { get; set; }
    }
    public class GetHajjYearListHandler : IRequestHandler<GetHajjYearList, List<HajjYearModel>>
    {
        private AppDbContext Context { get; set; }
        public GetHajjYearListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<HajjYearModel>> Handle(GetHajjYearList request, CancellationToken cancellationToken)
        {
            var query = Context.HajjYears.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new HajjYearModel
            {
                Id = e.Id,
                YearId = e.YearId,
                YearName = e.Year.Name,
            }).ToListAsync();
        }
    }
}
