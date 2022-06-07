using App.Application.Emara.Models;
using App.Application.Emara.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Emara.Commands
{
    public class CreateEmaraCommand : IRequest<List<SearchEmaraModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string FullAddress { get; set; }
        public int YearId { get; set; }
        public int? EmaraType { get; set; }
        public int? EmaraZone { get; set; }
        public int? Capacity { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string LocationName { get; set; }
        public int? YearName { get; set; }
    }
    public class CreateEmaraCommandHandler : IRequestHandler<CreateEmaraCommand, List<SearchEmaraModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateEmaraCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchEmaraModel>> Handle(CreateEmaraCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Emara = request.Id != 0 ? context.Emaras.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Emara();
            IEnumerable<SearchEmaraModel> result = new List<SearchEmaraModel>();
            Emara.Id = request.Id;
            Emara.Name = request.Name;
            Emara.LocationId = request.LocationId;
            Emara.FullAddress = request.FullAddress;
            Emara.YearId= request.YearId;
            Emara.EmaraZone = request.EmaraZone;
            Emara.EmaraType = request.EmaraType;
            Emara.Capacity = request.Capacity;


            if (request.Id == 0)
            {
                Emara.ModifiedBy = "";
                Emara.ModifiedOn = DateTime.Now;
                Emara.CreatedBy = CurrentUserId;
                Emara.CreatedOn = DateTime.Now;
                context.Emaras.Add(Emara);
            }
            else
            {
                Emara.ModifiedBy += "," + CurrentUserId; ;
                Emara.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchEmaraQuery() { Id = Emara.Id });
            return result.ToList();
        }
    }
}
