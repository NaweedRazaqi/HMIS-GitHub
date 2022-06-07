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
    public class SearchMoneyBackQuery : IRequest<IEnumerable<SearchMoneyBackModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? YearId { get; set; }
        public int? HajjYearId { get; set; }
        public string NumberMaktoobBank { get; set; }
        public int? CurrencyId { get; set; }
    }
    public class SearchMoneyBackQueryHandler : IRequestHandler<SearchMoneyBackQuery, IEnumerable<SearchMoneyBackModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMoneyBackQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMoneyBackModel>> Handle(SearchMoneyBackQuery request, CancellationToken cancellationToken)
        {
            var query = context.MoneyBacks.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.NumberMaktoobBank))
            {
                query = query.Where(e => e.NumberMaktoobBank == request.NumberMaktoobBank);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.HajjYearId != null)
            {
                query = query.Where(e => e.HajjYearId == request.HajjYearId);
            }
            if (request.CurrencyId != null)
            {
                query = query.Where(e => e.CurrencyId == request.CurrencyId);
            }
            return await query.Select(p => new SearchMoneyBackModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                YearId = p.YearId,
                YearName = p.Year.Name,
                HajjYearId = p.HajjYearId,
                HajjYearName = p.HajjYear.Year.Name,
                NumberMaktoobBank = p.NumberMaktoobBank,
                MoneyReturnDate = p.MoneyReturnDate,
                CurrencyId = p.CurrencyId,
                CurrencyName = p.Currency.Dari,
                ReturnedAmount = p.ReturnedAmount,
                RelativeId = p.RelativeId,
                RelativeName = p.Relative.FirstName + " " + p.Relative.LastName + " ولد " + p.Relative.FatherName,
                Justification  = p.Justification,
                CheckedBy = p.CheckedBy,
                Comments = p.Comments,
                MoneyReturnDateShamsi = PersianDate.Convert(p.MoneyReturnDate).DateString
            }).ToListAsync();
        }
    }
}
