using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Finance.Commands
{
    public class CreateMoneyBackCommand : IRequest<List<SearchMoneyBackModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int HajjYearId { get; set; }
        public string NumberMaktoobBank { get; set; }
        public DateTime MoneyReturnDate { get; set; }
        public int CurrencyId { get; set; }
        public int ReturnedAmount { get; set; }
        public int RelativeId { get; set; }
        public string Justification { get; set; }
        public string CheckedBy { get; set; }
        public string Comments { get; set; }

    }
    public class CreateMoneyBackCommandHandler : IRequestHandler<CreateMoneyBackCommand, List<SearchMoneyBackModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateMoneyBackCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchMoneyBackModel>> Handle(CreateMoneyBackCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var MoneyBack = request.Id != 0 ? context.MoneyBacks.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.MoneyBack();
            IEnumerable<SearchMoneyBackModel> result = new List<SearchMoneyBackModel>();
                MoneyBack.Id = request.Id;
                MoneyBack.CandidateId = request.CandidateId;
                MoneyBack.YearId = request.YearId;
                MoneyBack.HajjYearId = request.HajjYearId;
                MoneyBack.NumberMaktoobBank = request.NumberMaktoobBank;
                MoneyBack.MoneyReturnDate = request.MoneyReturnDate;
                MoneyBack.CurrencyId = request.CurrencyId;
                MoneyBack.ReturnedAmount = request.ReturnedAmount;
                MoneyBack.RelativeId = request.RelativeId;
                MoneyBack.Justification = request.Justification;
                MoneyBack.CheckedBy = request.CheckedBy;
                MoneyBack.Comments = request.Comments;
            if (request.Id == 0)
            {
                MoneyBack.ModifiedBy = "";
                MoneyBack.ModifiedOn = DateTime.Now;
                MoneyBack.CreatedBy = CurrentUserId;
                MoneyBack.CreatedOn = DateTime.Now;
                context.MoneyBacks.Add(MoneyBack);
            }
            else
            {
                MoneyBack.ModifiedBy += "," + CurrentUserId; ;
                MoneyBack.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMoneyBackQuery() { Id = MoneyBack.Id });
            return result.ToList();
        }
    }
}
