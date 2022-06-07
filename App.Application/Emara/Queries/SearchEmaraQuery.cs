using App.Application.Emara.Models;
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

namespace App.Application.Emara.Queries
{
    public class SearchEmaraQuery : IRequest<IEnumerable<SearchEmaraModel>>
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? EmaraType { get; set; }
        public int? EmaraZone { get; set; }
    }
    public class SearchEmaraQueryHandler : IRequestHandler<SearchEmaraQuery, IEnumerable<SearchEmaraModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchEmaraQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchEmaraModel>> Handle(SearchEmaraQuery request, CancellationToken cancellationToken)
        {
            var query = context.Emaras.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            return await query.Select(p => new SearchEmaraModel
            {
                Id = p.Id,
                Name = p.Name,
                LocationId = p.LocationId,
                LocationName = p.Location.Dari,
                FullAddress = p.FullAddress,
                YearId = p.YearId,
                YearName = p.Year.Name,
                EmaraZone = p.EmaraZone,
                EmaraType = p.EmaraType,
                Capacity = p.Capacity,
                EmaraZoneName = p.EmaraZoneNavigation.Name,
                EmaraTypeName = p.EmaraTypeNavigation.Name,
            }).ToListAsync();
        }
    }
}
