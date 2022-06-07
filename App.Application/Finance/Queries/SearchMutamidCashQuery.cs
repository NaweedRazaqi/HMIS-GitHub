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
    public class SearchMutamidCashQuery : IRequest<IEnumerable<SearchMutamidCashModel>>
    {
        public int Id { get; set; }
        public int? NumberMaktoob { get; set; }
        public int? HukamNumber { get; set; }
        public DateTime? MaktoobDate { get; set; }
        public int? CurrencyId { get; set; }
        public int? IstelamNumber { get; set; }
        public DateTime? IstelamDate { get; set; }
    }
    public class SearchMutamidCashQueryHandler : IRequestHandler<SearchMutamidCashQuery, IEnumerable<SearchMutamidCashModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMutamidCashQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMutamidCashModel>> Handle(SearchMutamidCashQuery request, CancellationToken cancellationToken)
        {
            var query = context.MutamidCashes.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CurrencyId != null)
            {
                query = query.Where(e => e.CurrencyId == request.CurrencyId);
            }
            if (request.IstelamNumber != null)
            {
                query = query.Where(e => e.IstelamNumber == request.IstelamNumber);
            }
            if (request.IstelamDate !=  null)
            {
                query = query.Where(e => e.IstelamDate == request.IstelamDate);
            }
            if (request.MaktoobDate != null)
            {
                query = query.Where(e => e.MaktoobDate == request.MaktoobDate);
            }
            if (request.IstelamDate != null)
            {
                query = query.Where(e => e.NumberMaktoob == request.NumberMaktoob);
            }
            return await query.Select(p => new SearchMutamidCashModel
            {
                Date = p.Date,
                DateShamsi = PersianDate.Convert( p.Date ).DateString,
                Explanation = p.Explanation,
                NumberMaktoob = p.NumberMaktoob,
                HukamNumber = p.HukamNumber,
                MaktoobDate = p.MaktoobDate,
                MaktoobDateShamsi = PersianDate.Convert(p.MaktoobDate).DateString,
                MutamidId = p.MutamidId,
                CurrencyId = p.CurrencyId,
                CurrencyName = p.Currency.Dari,
                Amount = p.Amount,
                ExchangeRate = p.ExchangeRate,
                ExpenseCenterId = p.ExpenseCenterId,
                IstelamNumber = p.IstelamNumber,
                IstelamDate = p.IstelamDate,
                MutamidName = p.Mutamid.Name,
                IstelamDateShamsi = PersianDate.Convert( p.IstelamDate ).DateString,
        }).ToListAsync();
       }
    }
}
