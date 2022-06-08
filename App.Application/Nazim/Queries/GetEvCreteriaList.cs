using App.Application.Nazim.Models;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Nazim.Queries
{

    public class GetEvCreteriaList : IRequest<IEnumerable<EvCreteriaSearchModel>>
    {
        public int Id { get; set; }
        public int? EvZoneTypeId { get; set; }
    }

    public class GetEvCreteriaListHandler : IRequestHandler<GetEvCreteriaList, IEnumerable<EvCreteriaSearchModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        public GetEvCreteriaListHandler(AppDbContext context, ICurrentUser currentUser)
        {
            this.context = context;
            User = currentUser;
        }

        public async Task<IEnumerable<EvCreteriaSearchModel>> Handle(GetEvCreteriaList request, CancellationToken cancellationToken)
        {
            var query = context.EvCreterias.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.EvZoneTypeId != 0)
            {
                query = query.Where(e => e.EvZoneTypeId == request.EvZoneTypeId);
            }

            return await query.Select(p => new EvCreteriaSearchModel
            {
                Id = p.Id,
                Name = p.Name,
                EvZoneTypeId = p.EvZoneTypeId
            }).ToListAsync();
        }
    }
}