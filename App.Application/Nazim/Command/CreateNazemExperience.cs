using App.Application.Nazim.Models;
using App.Application.Nazim.Queries;
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

namespace App.Application.Nazim.Command
{

    public class CreateNazemExperience : IRequest<List<SearchNazemExperienceModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? PrevouseHajCount { get; set; }
        public int? ExpenseType { get; set; }
        public int? YearId { get; set; }
    }

    public class CreateNazemExperienceHandler : IRequestHandler<CreateNazemExperience, List<SearchNazemExperienceModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateNazemExperienceHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }

        public async Task<List<SearchNazemExperienceModel>> Handle(CreateNazemExperience request, CancellationToken cancellationToken)
        {
            IEnumerable<SearchNazemExperienceModel> result = new List<SearchNazemExperienceModel>();

            var ed = request.Id != 0 ? context.NazemExperiences.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.NazemExperience();
            int CurrentUserId = await currentUser.GetUserId();


            var isemployed = context.Candidates.Where(c => c.Id == request.CandidateId && c.CandidateTypeId == 2).Select(se => se.IsEmployed).SingleOrDefault();

            if (isemployed == false || isemployed == null)
            {
                throw new BusinessRulesException("شخص مذکور واجد شرایط برای ثبت تجربه نمیباشد نمیباشد!");
            }
            ed.CandidateId = request.CandidateId;
            ed.PrevouseHajCount = request.PrevouseHajCount;
            ed.YearId = request.YearId;
            ed.ExpenseType = request.ExpenseType;
            if (request.Id == 0)
            {
                ed.ModifiedBy = "";
                ed.CreatedOn = DateTime.Now;
                ed.CreatedBy = CurrentUserId;
                ed.CreatedOn = DateTime.Now;
                context.NazemExperiences.Add(ed);
            }
            else
            {
                ed.ModifiedBy += "," + CurrentUserId;
                ed.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchNazemExperience() { Id = ed.Id });

            return result.ToList();
        }
    }
}