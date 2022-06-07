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
    public class SearchProvinceCapacityQuery : IRequest<IEnumerable<SearchProvinceCapacityModel>>
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int? ProvinceId { get; set; }
        public long? ProvinceCapacity { get; set; }
        public long? TotalCapacity { get; set; }
        public int? CandidateTypeId { get; set; }
        public int TotalId { get; set; }
    }
    public class SearchProvinceCapacityQueryHandler : IRequestHandler<SearchProvinceCapacityQuery, IEnumerable<SearchProvinceCapacityModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchProvinceCapacityQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchProvinceCapacityModel>> Handle(SearchProvinceCapacityQuery request, CancellationToken cancellationToken)
        {
            var proId = context.Locations.Where(pid => pid.Id == request.ProvinceId).Select(pid=>pid.Id).Count();
            var query = context.ProvincesCapacities.AsQueryable();
           
            if (request.ProvinceId.HasValue)
            {
                query = query.Where(p => p.ProvinceId == request.ProvinceId);
            }
            if (request.YearId != 0)
            {
                query = query.Where(e => e.YearId ==request.YearId);
            }
            return await query.Select(yc => new SearchProvinceCapacityModel
            {
                Id = yc.Id,
                YearId=yc.YearId,
                ProvinceId= yc.ProvinceId,
                ProvinceCapacity=yc.ProvinceCapacity,
                Provinces=yc.Province.Dari,
                YearName =yc.Year.Name,
                CandidateTypeId = yc.CandidateTypeId,
                CandidateTypeIdText = yc.CandidateType.Dari
            }).ToListAsync();
        }
    }
}
