using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateCancelCandidateCommand : IRequest<List<SearchCancelCandidateModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public string CancelReasons { get; set; }
        public int? HajjProcessId { get; set; }
    }
    public class CreateCancelCandidateCommandHandler : IRequestHandler<CreateCancelCandidateCommand, List<SearchCancelCandidateModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateCancelCandidateCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchCancelCandidateModel>> Handle(CreateCancelCandidateCommand request, CancellationToken cancellationToken)
        {
            //var hajprocessstatus = new Domain.Entity.prf.Candidate();
            int CurrentUserId = await currentUser.GetUserId();
            var CancelCandidate = request.Id != 0 ? context.CancelCandidates.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.CancelCandidate();
            IEnumerable<SearchCancelCandidateModel> result = new List<SearchCancelCandidateModel>();
            CancelCandidate.Id = request.Id;
            CancelCandidate.CandidateId = request.CandidateId;
            CancelCandidate.Date = request.Date;
            CancelCandidate.CancelReasons = request.CancelReasons;
            CancelCandidate.Remarks = request.Remarks;
            //hajprocessstatus.HajjProcessId = request.HajjProcessId;
           
            //context.Candidates.Add(hajprocessstatus);

            if (request.Id == 0)
            {
                CancelCandidate.ModifiedBy = "";
                CancelCandidate.ModifiedOn = DateTime.Now;
                CancelCandidate.CreatedBy = CurrentUserId;
                CancelCandidate.CreatedOn = DateTime.Now;


                context.CancelCandidates.Add(CancelCandidate);
            }

            else
            {
                CancelCandidate.ModifiedBy += "," + CurrentUserId; ;
                CancelCandidate.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchCancelCandidateQuery() { Id = request.Id });
            return result.ToList();

        }
    }
}
