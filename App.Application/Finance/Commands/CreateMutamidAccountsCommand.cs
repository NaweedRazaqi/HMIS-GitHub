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
    public class CreateMutamidAccountsCommand : IRequest<List<SearchMutamidAccountsModel>>
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int MutamidId { get; set; }
        public int Amount { get; set; }
        public int YearId { get; set; }
        public DateTime Date { get; set; }

    }
    public class CreateMutamidAccountsCommandHandler : IRequestHandler<CreateMutamidAccountsCommand, List<SearchMutamidAccountsModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateMutamidAccountsCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchMutamidAccountsModel>> Handle(CreateMutamidAccountsCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var MutamidAccounts = request.Id != 0 ? context.MutamidAccounts.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.MutamidAccounts();
            IEnumerable<SearchMutamidAccountsModel> result = new List<SearchMutamidAccountsModel>();
            MutamidAccounts.Date = request.Date;
            MutamidAccounts.YearId= request.YearId;
            MutamidAccounts.MutamidId= request.MutamidId;
            MutamidAccounts.CurrencyId = request.CurrencyId;
            MutamidAccounts.Amount = request.Amount;
            if (request.Id == 0)
            {
                MutamidAccounts.ModifiedBy = "";
                MutamidAccounts.ModifiedOn = DateTime.Now;
                MutamidAccounts.CreatedBy = CurrentUserId;
                MutamidAccounts.CreatedOn = DateTime.Now;
                context.MutamidAccounts.Add(MutamidAccounts);
            }
            else
            {
                MutamidAccounts.ModifiedBy += "," + CurrentUserId; ;
                MutamidAccounts.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMutamidAccountsQuery() { Id = MutamidAccounts.Id });
            return result.ToList();
        }
    }
}
