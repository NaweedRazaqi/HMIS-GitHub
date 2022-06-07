using App.Application.Qouta.Models;
using App.Persistence.Context;
using Clean.Common.Exceptions;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Qouta.Queries
{
    public class SearchQoutaQuery : IRequest<IEnumerable<SearchQoutaModel>>
    {
        public int Id { get; set; }
        public int? Organizationid { get; set; }
        public int? YearId { get; set; }
    }
    public class SearchQoutaQueryHandler : IRequestHandler<SearchQoutaQuery, IEnumerable<SearchQoutaModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchQoutaQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchQoutaModel>> Handle(SearchQoutaQuery request, CancellationToken cancellationToken)
        {

           if(request.Organizationid == null && request.YearId == null)
           {
                throw new BusinessRulesException("لطفا اداره و سال را انتخاب نمایید .");
            }
            var query = context.Qoutas.AsQueryable();
            var count = context.SpecialEntities.Where(p => p.OrganizationId == request.Organizationid && p.YearId == request.YearId).Count();

            var qoutacount = query.Where(o => o.OrganizationId == request.Organizationid && o.YearId == request.YearId).Select(p => p.QoutaAmount).SingleOrDefault();

            int totalRemainingQouta = (int)(qoutacount - count);
            var finalremainquota = 0;
            if(totalRemainingQouta == 0)
            {
                finalremainquota = 0;
            }
            else
            {
                finalremainquota = (int)totalRemainingQouta;
            }
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.Organizationid != null && request.YearId !=null)
            {
                query = query.Where(e => e.OrganizationId == request.Organizationid && e.YearId == request.YearId);
            }
            return await query.Select(p => new SearchQoutaModel
            {
                Id = p.Id,
                QoutaAmount = p.QoutaAmount,
                YearId = p.YearId,
                Year = p.Year.Name.ToString(),
                OrganizationId = p.OrganizationId,
                organName = p.Organization.Dari,
                remain = finalremainquota

            }).ToListAsync();
        }
    }
}
