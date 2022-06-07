using App.Application.Mosque.Models;
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

namespace App.Application.Mosque.Queries
{
    public class SearchMosqueQuery : IRequest<IEnumerable<SearchMosqueModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
    }
    public class SearchMosqueQueryHandler : IRequestHandler<SearchMosqueQuery, IEnumerable<SearchMosqueModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMosqueQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMosqueModel>> Handle(SearchMosqueQuery request, CancellationToken cancellationToken)
        {
            var query = context.Mosques.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.ProvinceId != null)
            {
                query = query.Where(e => e.ProvinceId == request.ProvinceId);
            }
            if (request.DistrictId != null)
            {
                query = query.Where(e => e.DistrictId == request.DistrictId);
            }
            if (!String.IsNullOrEmpty( request.Name ))
            {
                query = query.Where(e => e.Name == request.Name);
            }
            return await query.Select(p => new SearchMosqueModel
            {
                Id = p.Id,
                ProvinceId = p.ProvinceId,
                DistrictId = p.DistrictId,
                ProvinceName = p.Province.Dari,
                DistrictName = p.District.Dari,
                Name = p.Name,
            }).ToListAsync();
        }
    }
}
