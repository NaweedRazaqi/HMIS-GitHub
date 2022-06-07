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
    public class CreateNazamAssignmentCommand : IRequest<List<SearchNazamAssignmentModel>>
    {
        public int Id { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int NazamCandidateId { get; set; }
    }
    public class CreateNazamAssignmentCommandHandler : IRequestHandler<CreateNazamAssignmentCommand, List<SearchNazamAssignmentModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateNazamAssignmentCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchNazamAssignmentModel>> Handle(CreateNazamAssignmentCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var NazamAssignment = request.Id != 0 ? context.Candidates.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Candidate();
            IEnumerable<SearchNazamAssignmentModel> result = new List<SearchNazamAssignmentModel>();
            NazamAssignment.NazamCandidateId = request.NazamCandidateId;

            if (request.Id == 0)
            {
                NazamAssignment.ModifiedBy = "";
                NazamAssignment.ModifiedOn = DateTime.Now;
                NazamAssignment.CreatedBy = CurrentUserId;
                NazamAssignment.CreatedOn = DateTime.Now;
                context.Candidates.Add(NazamAssignment);
            }
            else
            {
                NazamAssignment.ModifiedBy += "," + CurrentUserId; ;
                NazamAssignment.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchNazamAssignmentQuery() { Id = NazamAssignment.Id });
            return result.ToList();

        }
    }
}
