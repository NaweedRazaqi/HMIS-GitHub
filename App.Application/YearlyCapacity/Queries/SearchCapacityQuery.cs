using App.Application.YearlyCapacity.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.YearlyCapacity.Queries
{
    public class SearchCapacityQuery : IRequest<IEnumerable<SearchCapacityModel>>
    {
        public int? Id { get; set; }
        public int? YearId { get; set; }
        public long? TotalCapacity { get; set; }
    }
    public class SearchCapacityQueryHandler : IRequestHandler<SearchCapacityQuery, IEnumerable<SearchCapacityModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchCapacityQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchCapacityModel>> Handle(SearchCapacityQuery request, CancellationToken cancellationToken)
        {
           
            var query = context.HajyearlyCapacities.AsQueryable();
            if (request.Id.HasValue)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.YearId.HasValue)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            return await query.Select(yc => new SearchCapacityModel
            {
                Id = yc.Id,
                YearId=yc.YearId,
                YearName    =yc.Year.Name,
                TotalCapacity=yc.TotalCapacity,
               // Remain=remain
                
              
            }).ToListAsync();
        }
    }
}
