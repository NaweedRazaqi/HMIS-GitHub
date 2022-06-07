using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateEducationCommand : IRequest<List<SearchEducationModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? DegreeId { get; set; }
        public long? FieldofstudyId { get; set; }
        public int? CountryId { get; set; }
        public int? UniversityId { get; set; }
        public int? StudyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, List<SearchEducationModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateEducationCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }

        public async Task<List<SearchEducationModel>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<SearchEducationModel> result = new List<SearchEducationModel>();

            var ed = request.Id !=0 ? context.Educations.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Education();
            int CurrentUserId = await currentUser.GetUserId();

            ed.DegreeId = request.DegreeId;
            ed.CandidateId = request.CandidateId;
            ed.FieldofstudyId = request.FieldofstudyId;
            ed.UniversityId = request.UniversityId;
            ed.CountryId = request.CountryId;
            ed.StudyTypeId = request.StudyTypeId;
            ed.StartDate = request.StartDate;
            ed.EndDate = request.EndDate;
            if (request.Id == 0)
            {
                ed.ModifiedBy = "";
                ed.CreatedOn = DateTime.Now;
                ed.CreatedBy = CurrentUserId;
                ed.CreatedOn = DateTime.Now;
                context.Educations.Add(ed);
            }
            else
            {
                ed.ModifiedBy += "," + CurrentUserId;
                ed.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchEducationQuery() { Id = ed.Id });

            return result.ToList();
        }
    }

}