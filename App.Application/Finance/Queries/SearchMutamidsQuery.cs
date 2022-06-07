using App.Application.Finance.Models;
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

namespace App.Application.Finance.Queries
{
    public class SearchMutamidsQuery : IRequest<IEnumerable<SearchMutamidsModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int? ProvincesId { get; set; }
        public int? DistrictsId { get; set; }
    }
    public class SearchMutamidsQueryHandler : IRequestHandler<SearchMutamidsQuery, IEnumerable<SearchMutamidsModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMutamidsQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMutamidsModel>> Handle(SearchMutamidsQuery request, CancellationToken cancellationToken)
        {
            var query = context.Mutamids.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.Name))
            {
                query = query.Where(e => e.Name == request.Name);
            }
            if (request.ProvincesId != null)
            {
                query = query.Where(e => e.ProvincesId == request.ProvincesId);
            }
            if (request.DistrictsId != null)
            {
                query = query.Where(e => e.DistrictsId == request.DistrictsId);
            }
            if (!String.IsNullOrEmpty(request.JobTitle))
            {
                query = query.Where(e => e.Jobtitle == request.JobTitle);
            }
            return await query.Select(p => new SearchMutamidsModel
            {
                Id = p.Id,
                Name = p.Name,
                Jobtitle = p.Jobtitle,
                ProvincesId = p.ProvincesId,
                DistrictsId = p.DistrictsId,
                ProvincesName = p.Provinces.Dari,
                DistrictsName = p.Districts.Dari,
                Office = p.Office,
                IsActive = p.IsActive == true ? 1 : 0,
                IsActiveName = p.IsActive == true ? "بلی" : "نخیر",
            }).ToListAsync();
        }
    }
}
