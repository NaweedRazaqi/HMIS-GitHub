using App.Application.YearlyCapacity.Models;
using App.Persistence.Context;
using App.Application.YearlyCapacity.Queries;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clean.Common.Exceptions;

namespace App.Application.YearlyCapacity.Commands
{
    public class CreateCapacityCommand : IRequest<List<SearchCapacityModel>>
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public long? TotalCapacity { get; set; }

    }
    public class CreateCapacityCommandHandler : IRequestHandler<CreateCapacityCommand, List<SearchCapacityModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateCapacityCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchCapacityModel>> Handle(CreateCapacityCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var pc = request.Id != 0 ? context.HajyearlyCapacities.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.HajyearlyCapacity();
            IEnumerable<SearchCapacityModel> result = new List<SearchCapacityModel>();

            var duplicate = context.HajyearlyCapacities.Where(d => d.YearId == request.YearId).Count();
            if (duplicate > 0)
            {
                throw new BusinessRulesException("سهمیه سال مذکور قبلا ثبت گریده است.");
            }
            else
            {
                pc.Id = request.Id;
                pc.YearId = request.YearId;
                pc.TotalCapacity = request.TotalCapacity;

                if (request.Id == 0)
                {
                    pc.ModifiedBy = "";
                    pc.ModifiedOn = DateTime.Now;
                    pc.CreatedBy = CurrentUserId;
                    pc.CreatedOn = DateTime.Now;
                    context.HajyearlyCapacities.Add(pc);
                }
               
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchCapacityQuery() { Id = pc.Id });
            return result.ToList();
        }
    }
}
