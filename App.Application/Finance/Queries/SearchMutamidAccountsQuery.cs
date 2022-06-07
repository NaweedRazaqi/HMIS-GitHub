using App.Application.Finance.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
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
    public class SearchMutamidAccountsQuery : IRequest<IEnumerable<SearchMutamidAccountsModel>>
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int? CurrencyId { get; set; }
        public int? MutamidId { get; set; }
    }
    public class SearchMutamidAccountsQueryHandler : IRequestHandler<SearchMutamidAccountsQuery, IEnumerable<SearchMutamidAccountsModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMutamidAccountsQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMutamidAccountsModel>> Handle(SearchMutamidAccountsQuery request, CancellationToken cancellationToken)
        {
            var query = context.MutamidAccounts.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.MutamidId != null)
            {
                query = query.Where(e => e.MutamidId == request.MutamidId);
            }
            if (request.CurrencyId != null)
            {
                query = query.Where(e => e.CurrencyId == request.CurrencyId);
            }
            return await query.Select(p => new SearchMutamidAccountsModel
            {
                Id = p.Id,
                Date = p.Date,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                CurrencyId = p.CurrencyId,
                CurrencyName = p.Currency.Dari,
                MutamidId = p.MutamidId,
                MutamidName = p.Mutamid.Name,
                Amount = p.Amount,
                YearId = p.YearId,
                YearName = p.Year.Name,
            }).ToListAsync();
        }
    }
}
