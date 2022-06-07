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
   public class GetHajjprocessStatus: IRequest<List<HajjProcessStatusModel>>
    {
        public int? ID { get; set; }
    }

    public class GetHajjprocessStatusHandler : IRequestHandler<GetHajjprocessStatus, List<HajjProcessStatusModel>>
{
    private AppDbContext Context { get; set; }
    public GetHajjprocessStatusHandler(AppDbContext context)
    {
        Context = context;
    }

        public async Task<List<HajjProcessStatusModel>> Handle(GetHajjprocessStatus request, CancellationToken cancellationToken)
        {
            var query = Context.HajjprocessStatuses.AsQueryable();
            if (request.ID.HasValue)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new HajjProcessStatusModel
            {
                Id = e.Id,
                Name = e.Name,
                Dari=e.Dari,
                Pashto=e.Pashto
                
            }).ToListAsync();
        }
    }
}
