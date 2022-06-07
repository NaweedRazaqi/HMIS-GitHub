using App.Application.Mosque.Models;
using App.Application.Mosque.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Mosque.Commands
{
    public class CreateMosqueCommand : IRequest<List<SearchMosqueModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class CreateEmaraCommandHandler : IRequestHandler<CreateMosqueCommand, List<SearchMosqueModel>>
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
        public async Task<List<SearchMosqueModel>> Handle(CreateMosqueCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Mosque = request.Id != 0 ? context.Mosques.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Mosque();
            IEnumerable<SearchMosqueModel> result = new List<SearchMosqueModel>();
            Mosque.Id = request.Id;
            Mosque.ProvinceId = request.ProvinceId;
            Mosque.DistrictId = request.DistrictId;
            Mosque.Name = request.Name;
        
            if (request.Id == 0)
            {
                Mosque.ModifiedBy = "";
                Mosque.ModifiedOn = DateTime.Now;
                Mosque.CreatedBy = CurrentUserId;
                Mosque.CreatedOn = DateTime.Now;
                context.Mosques.Add(Mosque);
            }
            else
            {
                Mosque.ModifiedBy += "," + CurrentUserId; ;
                Mosque.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMosqueQuery() { Id = Mosque.Id });
            return result.ToList();
        }
    }
}
