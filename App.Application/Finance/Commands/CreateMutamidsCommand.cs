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
    public class CreateMutamidsCommand : IRequest<List<SearchMutamidsModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Jobtitle { get; set; }
        public string Office { get; set; }
        public int? ProvincesId { get; set; }
        public int? DistrictsId { get; set; }
        public bool IsActive { get; set; }

    }
    public class CreateMutamidsCommandHandler : IRequestHandler<CreateMutamidsCommand, List<SearchMutamidsModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateMutamidsCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchMutamidsModel>> Handle(CreateMutamidsCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Mutamids = request.Id != 0 ? context.Mutamids.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Mutamids();
            IEnumerable<SearchMutamidsModel> result = new List<SearchMutamidsModel>();
            Mutamids.Name = request.Name;
            Mutamids.Jobtitle = request.Jobtitle;
            Mutamids.Office = request.Office;
            Mutamids.ProvincesId = request.ProvincesId;
            Mutamids.DistrictsId = request.DistrictsId;
            Mutamids.IsActive = request.IsActive;
            if (request.Id == 0)
            {
                Mutamids.ModifiedBy = "";
                Mutamids.ModifiedOn = DateTime.Now;
                Mutamids.CreatedBy = CurrentUserId;
                Mutamids.CreatedOn = DateTime.Now;
                context.Mutamids.Add(Mutamids);
            }
            else
            {
                Mutamids.ModifiedBy += "," + CurrentUserId; ;
                Mutamids.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMutamidsQuery() { Id = Mutamids.Id });
            return result.ToList();
        }
    }
}
