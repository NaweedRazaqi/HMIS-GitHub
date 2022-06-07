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
    public class CreateContractInstallmentCommand : IRequest<List<SearchContractInstallmentModel>>
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int InstallmentNo { get; set; }
        public int YearId { get; set; }
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
        public int ExchangeRate { get; set; }
        public int ExchangedAmount { get; set; }
        public string TaxPercentage { get; set; }
        public int Tax { get; set; }
        public string PrivateSector { get; set; }
        public string PrivateSectorPercentage { get; set; }
        public string Penalty { get; set; }
        public int NetAmount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }

    }
    public class CreateContractInstallmentCommandHandler : IRequestHandler<CreateContractInstallmentCommand, List<SearchContractInstallmentModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateContractInstallmentCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchContractInstallmentModel>> Handle(CreateContractInstallmentCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var ContractInstallment = request.Id != 0 ? context.ContractInstallments.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.ContractInstallment();
            IEnumerable<SearchContractInstallmentModel> result = new List<SearchContractInstallmentModel>();
                ContractInstallment.Id = request.Id;
                ContractInstallment.ContractId = request.ContractId;
                ContractInstallment.InstallmentNo = request.InstallmentNo;
                ContractInstallment.CurrencyId = request.CurrencyId;
                ContractInstallment.YearId = request.YearId;
                ContractInstallment.Date = request.Date;
                ContractInstallment.Amount = request.Amount;
                ContractInstallment.ExchangedAmount = request.ExchangedAmount;
                ContractInstallment.ExchangeRate = request.ExchangeRate;
                ContractInstallment.TaxPercentage = request.TaxPercentage;
                ContractInstallment.Tax = request.Tax;
                ContractInstallment.PrivateSector = request.PrivateSector;
                ContractInstallment.PrivateSectorPercentage = request.PrivateSectorPercentage;
                ContractInstallment.Penalty = request.Penalty;
                ContractInstallment.NetAmount = request.NetAmount;
                ContractInstallment.Comments = request.Comments;
            if (request.Id == 0)
            {
                ContractInstallment.ModifiedBy = "";
                ContractInstallment.ModifiedOn = DateTime.Now;
                ContractInstallment.CreatedBy = CurrentUserId;
                ContractInstallment.CreatedOn = DateTime.Now;
                context.ContractInstallments.Add(ContractInstallment);
            }
            else
            {
                ContractInstallment.ModifiedBy += "," + CurrentUserId; ;
                ContractInstallment.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchContractInstallmentQuery() { Id = ContractInstallment.Id });
            return result.ToList();
        }
    }
}
