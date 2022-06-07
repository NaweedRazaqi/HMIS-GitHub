using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Exceptions;
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
    public class CreateJobCommand : IRequest<List<SearchJobModel>>
    {
        public int? Id { get; set; }
        public int CandidateId { get; set; }
        public int? OrganizationId { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? JobTilteId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? RankId { get; set; }
        public string? JobTitleText { get; set; }

    }
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, List<SearchJobModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateJobCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchJobModel>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {

            var isemployed = context.Candidates.Where(c => c.Id == request.CandidateId && c.CandidateTypeId == 2).Select(se => se.IsEmployed).SingleOrDefault();

            if(isemployed == false || isemployed == null)
            {
                throw new BusinessRulesException("شخص مذکور واجد شرایط برای ثبت وظیفه نمیباشد!");
            }
            int CurrentUserId = await currentUser.GetUserId();
            var Job = request.Id.HasValue ? context.Jobs.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Job();
            IEnumerable<SearchJobModel> result = new List<SearchJobModel>();


            Job.CandidateId = request.CandidateId;
            Job.OrganizationId = request.OrganizationId;
            Job.JobTilteId = request.JobTilteId;
            Job.ProvinceId = request.ProvinceId;
            Job.DistrictId = request.DistrictId;
            Job.RankId = request.RankId;
            Job.JobTitleText = request.JobTitleText;

            if (request.Id.HasValue)
            {

                Job.ModifiedBy += "," + CurrentUserId; ;
                Job.ModifiedOn = DateTime.Now;
                
            }
            else
            {
                Job.CreatedBy = CurrentUserId;
                Job.CreatedOn = DateTime.Now;
                await context.Jobs.AddAsync(Job);
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchJobQuery() { Id = Job.Id });
            return result.ToList();
        }
    }
}
