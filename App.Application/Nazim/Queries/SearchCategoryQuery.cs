using App.Application.Nazim.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Nazim.Queries
{
    public class SearchCategoryQuery : IRequest<IEnumerable<EvcategoryModel>>
    {
        public int Id { get; set; }
        public int Nid { get; set; }
        public int? ZoneId { get; set; }
    }
    public class SearchCategoryQueryHandler : IRequestHandler<SearchCategoryQuery, IEnumerable<EvcategoryModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchCategoryQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<EvcategoryModel>> Handle(SearchCategoryQuery request, CancellationToken cancellationToken)
        {
            var query = context.Nerecords.AsQueryable();
            if (request.Nid != 0)
            {
                query = query.Where(e => e.Nid == request.Nid);
            } 
          
            return await query.Select(p => new EvcategoryModel
            {
                Id = p.Id,
                CandidateName=p.N.FirstName,
                Evid = p.Evid,
                category=p.Ev.Name,
                zone=p.Zone.Name,
                Nid = p.Nid,
                ResultId = p.ResultId,
                result=p.Result.Name,
                ZoneId=p.ZoneId,
                EvCreteriaId = p.EvCreteriaId
        }).ToListAsync();
        }
    }
}
