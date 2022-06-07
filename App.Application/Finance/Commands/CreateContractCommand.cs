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
    public class CreateContractCommand : IRequest<List<SearchContractModel>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContractDetails { get; set; }
        public string CompanyName { get; set; }
        public int LocationId { get; set; }
        public int ExpenseCenterId { get; set; }
        public int ContractNumber { get; set; }
        public int ContractAmount { get; set; }
        public string Comments { get; set; }

    }
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, List<SearchContractModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateContractCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchContractModel>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Contract = request.Id != 0 ? context.Contracts.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Contract();
            IEnumerable<SearchContractModel> result = new List<SearchContractModel>();
            Contract.Id = request.Id;
            Contract.Date = request.Date;
            Contract.StartDate = request.StartDate;
            Contract.EndDate = request.EndDate;
            Contract.ContractDetails = request.ContractDetails;
            Contract.ContractAmount = request.ContractAmount;
            Contract.ContractNumber = request.ContractNumber;
            Contract.LocationId = request.LocationId;
            Contract.CompanyName = request.CompanyName;
            Contract.ExpenseCenterId = request.ExpenseCenterId;
            Contract.Comments = request.Comments;
            if (request.Id == 0)
            {
                Contract.ModifiedBy = "";
                Contract.ModifiedOn = DateTime.Now;
                Contract.CreatedBy = CurrentUserId;
                Contract.CreatedOn = DateTime.Now;
                context.Contracts.Add(Contract);
            }
            else
            {
                Contract.ModifiedBy += "," + CurrentUserId; ;
                Contract.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchContractQuery() { Id = Contract.Id });
            return result.ToList();
        }
    }
}
