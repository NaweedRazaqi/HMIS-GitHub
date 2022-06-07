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
    public class CreateMutamidCashCommand : IRequest<List<SearchMutamidCashModel>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public int NumberMaktoob { get; set; }
        public int HukamNumber { get; set; }
        public DateTime MaktoobDate { get; set; }
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
        public int ExchangeRate { get; set; }
        public int ExpenseCenterId { get; set; }
        public int MutamidId { get; set; }
        public int IstelamNumber { get; set; }
        public DateTime IstelamDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class CreateMutamidCashCommandHandler : IRequestHandler<CreateMutamidCashCommand, List<SearchMutamidCashModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateMutamidCashCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchMutamidCashModel>> Handle(CreateMutamidCashCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var MobileCard = request.Id != 0 ? context.MutamidCashes.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.MutamidCashes();
            IEnumerable<SearchMutamidCashModel> result = new List<SearchMutamidCashModel>();
            MobileCard.Date = request.Date;
            MobileCard.Explanation= request.Explanation;
            MobileCard.NumberMaktoob = request.NumberMaktoob;
            MobileCard.HukamNumber = request.HukamNumber;
            MobileCard.MaktoobDate = request.MaktoobDate;
            MobileCard.MutamidId = request.MutamidId;
            MobileCard.CurrencyId = request.CurrencyId;
            MobileCard.Amount = request.Amount;
            MobileCard.ExchangeRate = request.ExchangeRate;
            MobileCard.ExpenseCenterId = request.ExpenseCenterId;
            MobileCard.IstelamNumber = request.IstelamNumber;
            MobileCard.IstelamDate = request.IstelamDate;
            if (request.Id == 0)
            {
                MobileCard.ModifiedBy = "";
                MobileCard.ModifiedOn = DateTime.Now;
                MobileCard.CreatedBy = CurrentUserId;
                MobileCard.CreatedOn = DateTime.Now;
                context.MutamidCashes.Add(MobileCard);
            }
            else
            {
                MobileCard.ModifiedBy += "," + CurrentUserId; ;
                MobileCard.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMutamidCashQuery() { Id = MobileCard.Id });
            return result.ToList();
        }
    }
}
