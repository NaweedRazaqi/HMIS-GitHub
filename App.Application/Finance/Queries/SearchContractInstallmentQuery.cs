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
    public class SearchContractInstallmentQuery : IRequest<IEnumerable<SearchContractInstallmentModel>>
    {
        public int Id { get; set; }
        public int? ContractId { get; set; }
        public int? YearId { get; set; }
        public int? CurrencyId { get; set; }
        public int? Amount { get; set; }
    }
    public class SearchContractInstallmentQueryHandler : IRequestHandler<SearchContractInstallmentQuery, IEnumerable<SearchContractInstallmentModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchContractInstallmentQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchContractInstallmentModel>> Handle(SearchContractInstallmentQuery request, CancellationToken cancellationToken)
        {
            var query = context.ContractInstallments.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.ContractId != null)
            {
                query = query.Where(e => e.ContractId == request.ContractId);
            }
            if (request.CurrencyId != null)
            {
                query = query.Where(e => e.CurrencyId == request.CurrencyId);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.Amount != null)
            {
                query = query.Where(e => e.Amount == request.Amount);
            }
            return await query.Select(p => new SearchContractInstallmentModel
            {
                Id = p.Id,
                ContractId =  p.ContractId,
                ContractName = p.Contract.ContractNumber,
                InstallmentNo = p.InstallmentNo,
                CurrencyId = p.CurrencyId,
                CurrencyName = p.Currency.Dari,
                YearId = p.YearId,
                YearName = p.Year.Name,
                Date = p.Date,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                Amount = p.Amount,
                ExchangedAmount = p.ExchangedAmount,
                ExchangeRate = p.ExchangeRate,
                TaxPercentage = p.TaxPercentage,
                Tax = p.Tax,
                PrivateSector = p.PrivateSector,
                PrivateSectorPercentage = p.PrivateSectorPercentage,
                Penalty = p.Penalty,
                NetAmount = p.NetAmount,
                Comments = p.Comments,
            }).ToListAsync();
        }
    }
}
