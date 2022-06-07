using App.Application.Qouta.Models;
using App.Application.Qouta.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Qouta.Commands
{
    public class CreateQoutaCommand : IRequest<List<SearchQoutaModel>>
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int? QoutaAmount { get; set; }
        public int? YearId { get; set; }
    }
    public class CreateQoutaCommandHandler : IRequestHandler<CreateQoutaCommand, List<SearchQoutaModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateQoutaCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchQoutaModel>> Handle(CreateQoutaCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Q = request.Id != 0 ? context.Qoutas.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Qouta();
            IEnumerable<SearchQoutaModel> result = new List<SearchQoutaModel>();
            Q.Id = request.Id;
            Q.OrganizationId = request.OrganizationId;
            Q.QoutaAmount = request.QoutaAmount;
            Q.YearId = request.YearId;


            if (request.Id == 0)
            {
                Q.ModifiedBy = "";
                Q.ModifiedOn = DateTime.Now;
                Q.CreatedBy = CurrentUserId;
                Q.CreatedOn = DateTime.Now;
                context.Qoutas.Add(Q);
            }
            else
            {
                Q.ModifiedBy += "," + CurrentUserId; ;
                Q.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchQoutaQuery() { Id = Q.Id });
            return result.ToList();
        }
    }
}
