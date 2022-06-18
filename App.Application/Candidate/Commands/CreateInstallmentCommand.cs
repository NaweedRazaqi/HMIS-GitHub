using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateInstallmentCommand : IRequest<List<SearchInstallmentModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int InstallmentTypeId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int RecipetNo { get; set; }
        public int BankId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyRate { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public int? InstallmentNo { get; set; }
        public int? DiscountId { get; set; }
        public int? Amountofdiscount { get; set; }
        public int? OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public int? OrdererId { get; set; }


    }
    public class CreateInstallmentCommandHandler : IRequestHandler<CreateInstallmentCommand, List<SearchInstallmentModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateInstallmentCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchInstallmentModel>> Handle(CreateInstallmentCommand request, CancellationToken cancellationToken)
        {

            string currentdate = PersianDate.GetFormatedString(DateTime.Now).Substring(14, 4);

            var yearlist = context.Years.Where(y => y.Name == Convert.ToInt32(currentdate)).Select(y => y.Id).SingleOrDefault();


            var candidateAmount = context.Installments.Where(e => e.CandidateId == request.CandidateId).Sum(e => e.Amount);

            var HajjFee = context.HajjYearlyFees.Where(h => h.YearId == yearlist).Select(h => h.Fee).SingleOrDefault();
            var count = context.Installments.Where(e => e.CandidateId == request.CandidateId).Count();
            if (count == 1)
            {
                var remaining = HajjFee - candidateAmount;

                if (request.Amount < remaining )
                {
                    throw new BusinessRulesException("مقدار فسظ دوم کم است.");
                }
                else if (request.Amount > remaining)
                {
                    throw new BusinessRulesException("مقدار فسظ دوم بشتر است.");
                }
            }
            else if (count >= 2)
            {
                throw new BusinessRulesException(" تعداد قسط ها تکمیل گردیده است!");
            }

            var HajjFeeCount = context.Installments.Where(i => i.CandidateId == request.CandidateId).Select(s => s.Amount).Single();

            int CurrentUserId = await currentUser.GetUserId();
            var Installment = request.Id != 0 ? context.Installments.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Installment();
            IEnumerable<SearchInstallmentModel> result = new List<SearchInstallmentModel>();
            Installment.Id = request.Id;
            Installment.CandidateId = request.CandidateId;
            Installment.BankId = request.BankId;
            Installment.Code = request.Code;
            Installment.CurrencyId = request.CurrencyId;
            Installment.InstallmentTypeId = request.InstallmentTypeId;
            Installment.RecipetNo = request.RecipetNo;
            Installment.Remarks = request.Remarks;
            Installment.Date = request.Date;
            Installment.CurrencyRate = request.CurrencyRate;
            Installment.Amount = request.Amount;
            Installment.InstallmentNo = request.InstallmentNo;
            Installment.DiscountId = request.DiscountId;
            Installment.Amountofdiscount = request.Amountofdiscount;
            Installment.OrderId = request.OrdererId;
            Installment.OrderNumber = request.OrderNumber;
            Installment.OrdererId = request.OrdererId;

            if (request.Id == 0)
            {
                Installment.ModifiedBy = "";
                Installment.ModifiedOn = DateTime.Now;
                Installment.CreatedBy = CurrentUserId;
                Installment.CreatedOn = DateTime.Now;
                context.Installments.Add(Installment);
            }
            else
            {
                Installment.ModifiedBy += "," + CurrentUserId; ;
                Installment.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchInstallmentQuery() { Id = Installment.Id });
            return result.ToList();

        }
    }
}
