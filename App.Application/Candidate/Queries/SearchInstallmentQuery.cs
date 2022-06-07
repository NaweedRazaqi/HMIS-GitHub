using App.Application.Candidate.Models;
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

namespace App.Application.Candidate.Queries
{
    public class SearchInstallmentQuery : IRequest<IEnumerable<SearchInstallmentModel>>
    {
        public int? Id { get; set; }
        public int CandidateId { get; set; }
        public int? BankId { get; set; }
        public int? InstallmentNo { get; set; }
    }
    public class SearchInstallmentQueryHandler : IRequestHandler<SearchInstallmentQuery, IEnumerable<SearchInstallmentModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchInstallmentQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchInstallmentModel>> Handle(SearchInstallmentQuery request, CancellationToken cancellationToken)
        {
          
          
            var query = context.Installments.AsQueryable();
            var inst1 = context.Installments.Where(ist => ist.InstallmentTypeId == 1).FirstOrDefault();
            if (request.Id.HasValue)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != 0)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.BankId != null)
            {
                query = query.Where(e => e.BankId == request.BankId);
            }
            if (request.InstallmentNo != null)
            {
                query = query.Where(e => e.InstallmentNo == request.InstallmentNo);
            }
            return await query.Select(p => new SearchInstallmentModel
            {
                Id = p.Id,
                Code = p.Code,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                InstallmentTypeId = p.InstallmentTypeId,
                InstallmentTypeName = p.InstallmentType.Dari,
                Date = p.Date,
                DateShamsi = PersianDate.Convert(p.Date).DateString,
                DateShamsi2 = context.Installments.Where(am => am.InstallmentTypeId == 2).Select(am => am.Date).SingleOrDefault().ToString(),
                Amount = context.Installments.Where(am=> am.InstallmentTypeId == 1).Select(am=> am.Amount).SingleOrDefault(),
                RecipetNo = p.RecipetNo,
                RecipetNo2 = context.Installments.Where(r=>r.InstallmentTypeId==2).Select(r=>r.RecipetNo).SingleOrDefault(),
                BankId = p.BankId,
                BankName = p.Bank.Name,
                CurrencyId = p.CurrencyId,
                CurrencyName = p.Currency.Dari,
                CurrencyRate = p.CurrencyRate,
                InstallmentNo= p.InstallmentNo,
                InstallmentNo2= context.Installments.Where(i => i.InstallmentTypeId == 2).Select(i => i.InstallmentNo).SingleOrDefault(),
                Remarks = p.Remarks,
                OrderId=p.OrderId,
                OrdererId=p.OrdererId,
                OrderNumber=p.OrderNumber,
                Amountofdiscount=p.Amountofdiscount,
                Orders=p.Order.Name,
                whoisorder=p.Orderer.Name,
                Discountid=p.DiscountId,
                Discount=p.Discount.Name,
                Amount2 = context.Installments.Where(am2=> am2.InstallmentTypeId == 2).Select(am2=> am2.Amount).SingleOrDefault()
                
            }).ToListAsync();
        }
    }
}
