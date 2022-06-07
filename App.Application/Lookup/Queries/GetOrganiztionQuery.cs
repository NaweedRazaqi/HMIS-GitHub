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
    public class GetOrganiztionQuery : IRequest<List<SearchOrganizationModel>>
    {
        public int? Id { get; set; }
        public int? OrognizationTypeID { get; set; }
        public bool ParentOnly { get; set; } = false;
    }
    public class GetOrganiztionQueryHandler : IRequestHandler<GetOrganiztionQuery, List<SearchOrganizationModel>>
    {
        private AppDbContext Context { get; set; }
        public GetOrganiztionQueryHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<SearchOrganizationModel>> Handle(GetOrganiztionQuery request, CancellationToken cancellationToken)
        {
            List<SearchOrganizationModel> list = new List<SearchOrganizationModel>();

            var query = Context.Organizations.AsQueryable();
            if (request.Id.HasValue)
            {
                query = query.Where(o => o.Id == request.Id);
            }
            if (request.OrognizationTypeID.HasValue)
                query = query.Where(ot => ot.OrganizationTypeId == request.OrognizationTypeID);


            list = await (from o in query
                          select new SearchOrganizationModel
                          {
                              Id = o.Id,
                              Code = o.Code,
                              Name = o.Name,
                              Dari = o.Dari,
                              Pashto = o.Pashto,
                              OrganizationTypeID = o.OrganizationTypeId

                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
