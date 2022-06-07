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
    public class SearchContractQuery : IRequest<IEnumerable<SearchContractModel>>
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class SearchContractQueryHandler : IRequestHandler<SearchContractQuery, IEnumerable<SearchContractModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchContractQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchContractModel>> Handle(SearchContractQuery request, CancellationToken cancellationToken)
        {
            var query = context.Contracts.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.StartDate != null)
            {
                query = query.Where(e => e.StartDate == request.StartDate);
            }
            if (request.EndDate != null)
            {
                query = query.Where(e => e.EndDate == request.EndDate);
            }
            if (request.Date != null)
            {
                query = query.Where(e => e.Date == request.Date);
            }
            if (request.LocationId != null)
            {
                query = query.Where(e => e.LocationId == request.LocationId);
            }
            return await query.Select(p => new SearchContractModel
            {
                Id = p.Id,
                Date = p.Date,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                StartDateShamsi = PersianDate.Convert(p.StartDate).DateString,
                EndDateShamsi = PersianDate.Convert(p.EndDate).DateString,
                ContractDetails = p.ContractDetails,
                ContractAmount = p.ContractAmount,
                ContractNumber = p.ContractNumber,
                CompanyName = p.CompanyName,
                LocationId = p.LocationId,
                LocationName = p.Location.Dari,
                ExpenseCenterId = p.ExpenseCenterId,
                ExpenseCenterName = p.ExpenseCenter.Dari,
                Comments = p.Comments,
            }).ToListAsync();
        }
    }
}
