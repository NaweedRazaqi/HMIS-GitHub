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
    public class SearchDailyExpensesQuery : IRequest<IEnumerable<SearchDailyExpensesModel>>
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public DateTime? Date { get; set; }
        public int? ExpenseTypeId { get; set; }
        public int? CurrencyId { get; set; }
    }
    public class SearchDailyExpensesQueryHandler : IRequestHandler<SearchDailyExpensesQuery, IEnumerable<SearchDailyExpensesModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchDailyExpensesQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchDailyExpensesModel>> Handle(SearchDailyExpensesQuery request, CancellationToken cancellationToken)
        {
            var query = context.DailyExpenses.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.CurrencyId != null)
            {
                query = query.Where(e => e.CurrencyId == request.CurrencyId);
            }
            if (request.ExpenseTypeId != null)
            {
                query = query.Where(e => e.ExpenseTypeId == request.ExpenseTypeId);
            }
            if (request.Date != null)
            {
                query = query.Where(e => e.Date == request.Date);
            }
            return await query.Select(p => new SearchDailyExpensesModel
            {
                Id = p.Id,
                YearId = p.YearId,
                YearName = p.Year.Name,
                Date = p.Date,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                ExpenseTypeId = p.ExpenseTypeId,
                M7number = p.M7number,
                M7date = p.M7date,
                M7dateShamsi = PersianDate.Convert(p.M7date).DateString,
                CurrencyId = p.CurrencyId,
                ConvertedCurrecyId = p.ConvertedCurrecyId,
                ExchangeRate = p.ExchangeRate,
                SpentFrom = p.SpentFrom,
                MutamidId = p.MutamidId,
                MutamidName = p.Mutamid.Name,
                NumberOfItems = p.NumberOfItems,
                TotalHawalaAmount = p.TotalHawalaAmount,
                ExchangedAmount = p.ExchangedAmount,
                TaxPercentage = p.TaxPercentage,
                Tax = p.Tax,
                PrivateSector = p.PrivateSector,
                PrivateSectorPercentage = p.PrivateSectorPercentage,
                Penalty = p.Penalty,
                NetAmount = p.NetAmount,
                NumberOfPages = p.NumberOfPages,
                MaktoobNo = p.MaktoobNo,
                MaktoobDate = p.MaktoobDate,
                MaktoobDateShamsi = PersianDate.Convert(p.MaktoobDate).DateString,
                HukamNo = p.HukamNo,
                HumkamDate = p.HumkamDate,
                Comments = p.Comments,
        }).ToListAsync();
        }
    }
}
