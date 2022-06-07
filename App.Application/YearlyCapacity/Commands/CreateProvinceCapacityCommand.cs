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

namespace App.Application.YearlyCapacity.Commands
{
    public class CreateProvinceCapacityCommand : IRequest<List<SearchProvinceCapacityModel>>
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public int ProvinceId { get; set; }
        public int TotalId { get; set; }
        public long? ProvinceCapacity { get; set; }
        public int? CandidateTypeId { get; set; }

    }
    public class CreateProvinceCapacityCommandHandler : IRequestHandler<CreateProvinceCapacityCommand, List<SearchProvinceCapacityModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateProvinceCapacityCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchProvinceCapacityModel>> Handle(CreateProvinceCapacityCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var pc = request.Id != 0 ? context.ProvincesCapacities.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.ProvincesCapacity();
            IEnumerable<SearchProvinceCapacityModel> result = new List<SearchProvinceCapacityModel>();
            var totalid = context.HajyearlyCapacities.Where(t => t.YearId == request.YearId).Select(t => t.Id).SingleOrDefault();
            var total = context.ProvincesCapacities.Where(yc => yc.ProvinceCapacity == request.ProvinceCapacity).Count();
            //pc.Id = request.Id;
            pc.YearId= request.YearId;
            pc.ProvinceId = request.ProvinceId;
            pc.TotalId = totalid;
            pc.ProvinceCapacity= request.ProvinceCapacity;
            pc.CandidateTypeId = request.CandidateTypeId;
            if (request.Id == 0)
            {
                pc.ModifiedBy = "";
                pc.ModifiedOn = DateTime.Now;
                pc.CreatedBy = CurrentUserId;
                pc.CreatedOn = DateTime.Now;
                context.ProvincesCapacities.Add(pc);
            }
            else
            {
                pc.ModifiedBy += "," + CurrentUserId; ;
                pc.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchProvinceCapacityQuery() { Id = pc.Id });
            return result.ToList();
        }
    }
}
