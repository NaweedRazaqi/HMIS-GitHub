using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
    public class GetCountriesLocation : IRequest<List<LocationModel>>
    {
        public long? Id { get; set; }
    }
    public class GetCountriesListHandler : IRequestHandler<GetCountriesLocation, List<LocationModel>>
    {
        private AppDbContext Context { get; set; }
        public GetCountriesListHandler(AppDbContext context)
        {
            this.Context = context;
        }

        public async Task<List<LocationModel>> Handle(GetCountriesLocation request, CancellationToken cancellationToken)
        {

            var query = Context.Locations.AsQueryable();

            return await query.Where(l => l.TypeId == 1).Select(e => new LocationModel
            {
                Id = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }

            ).ToListAsync();
        }
    }
}