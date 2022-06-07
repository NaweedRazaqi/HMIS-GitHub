using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateCandidateStatusCommand : IRequest<List<SearchCandidateStatusModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int StatusTypeId { get; set; }
        public int CprovincesId { get; set; }
        public string RoomNo { get; set; }
        public string Remarks { get; set; }
    }
    public class CreateCandidateStatusCommandHandler : IRequestHandler<CreateCandidateStatusCommand, List<SearchCandidateStatusModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateCandidateStatusCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchCandidateStatusModel>> Handle(CreateCandidateStatusCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var CandidateStatus = request.Id != 0 ? context.CandidateStatuses.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.CandidateStatus();
            IEnumerable<SearchCandidateStatusModel> result = new List<SearchCandidateStatusModel>();
            CandidateStatus.Id = request.Id;
            CandidateStatus.CandidateId = request.CandidateId;
            CandidateStatus.CprovincesId = request.CprovincesId;
            CandidateStatus.Remarks = request.Remarks;
            CandidateStatus.RoomNo = request.RoomNo;
            CandidateStatus.StatusTypeId = request.StatusTypeId;


            if (request.Id == 0)
            {
                CandidateStatus.ModifiedBy = "";
                CandidateStatus.ModifiedOn = DateTime.Now;
                CandidateStatus.CreatedBy = CurrentUserId;
                CandidateStatus.CreatedOn = DateTime.Now;
                context.CandidateStatuses.Add(CandidateStatus);
            }
            else
            {
                CandidateStatus.ModifiedBy += "," + CurrentUserId; ;
                CandidateStatus.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchCandidateStatusQuery() { Id = CandidateStatus.Id });
            return result.ToList();
        }
    }
}
