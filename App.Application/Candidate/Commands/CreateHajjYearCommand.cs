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
    public class CreateHajjYearCommand : IRequest<List<SearchHajjYearModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int YearId { get; set; }
        public int EnrollmentId { get; set; }
        public int ArchiveNo { get; set; }
        public int ProvincesId { get; set; }
    }
    public class CreateHajjYearCommandHandler : IRequestHandler<CreateHajjYearCommand, List<SearchHajjYearModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateHajjYearCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchHajjYearModel>> Handle(CreateHajjYearCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();

            var HajjYear = request.Id != 0 ? context.HajjYears.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.HajjYear();
            var Candidate = context.Candidates.Where(C => C.Id == request.CandidateId).Single();
            Candidate.IsSelected = true;
            IEnumerable<SearchHajjYearModel> result = new List<SearchHajjYearModel>();
            HajjYear.Id = request.Id;
            HajjYear.CandidateId = request.CandidateId;
            HajjYear.EnrollmentId = request.EnrollmentId;
            HajjYear.ProvincesId = request.ProvincesId;
            HajjYear.YearId = request.YearId;
            HajjYear.ArchiveNo = request.ArchiveNo;

            if (request.Id == 0)
            {
                HajjYear.ModifiedBy = "";
                HajjYear.ModifiedOn = DateTime.Now;
                HajjYear.CreatedBy = CurrentUserId;
                HajjYear.CreatedOn = DateTime.Now;
                context.HajjYears.Add(HajjYear);
            }
            else
            {
                HajjYear.ModifiedBy += "," + CurrentUserId; ;
                HajjYear.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchHajjYearQuery() { Id = HajjYear.Id });
            return result.ToList();
        }
    }
}
