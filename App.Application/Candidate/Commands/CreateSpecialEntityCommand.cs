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
    public class CreateSpecialEntityCommand : IRequest<List<SearchSpecialEntityModel>>
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
        public int? SpecialEntityTypeId { get; set; }
        public int? YearId { get; set; }
        public int? CandidateId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string DepartmentName { get; set; }
        public int? MaktubNumber { get; set; }
        public DateTime Date { get; set; }
        public string Refrence { get; set; }
        public string Discription { get; set; }
        public string ShoraName { get; set; }
    }
    public class CreateSpecialEntityCommandHandler : IRequestHandler<CreateSpecialEntityCommand, List<SearchSpecialEntityModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateSpecialEntityCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchSpecialEntityModel>> Handle(CreateSpecialEntityCommand request, CancellationToken cancellationToken)
        {
            
            int CurrentUserId = await currentUser.GetUserId();
            var qouta = context.Qoutas.Where(q => q.YearId == request.YearId && q.OrganizationId == request.OrganizationId).Select(q => q.QoutaAmount).SingleOrDefault();
            var counter = context.SpecialEntities.Where(q => q.OrganizationId == request.OrganizationId && q.YearId == request.YearId).Count();
           
            if (counter >= qouta)
            {
                throw new BusinessRulesException("از اداره مذکور برای سال فعلی سهمیه تکمیل است.");
            }
            var SE = request.Id != 0 ? context.SpecialEntities.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.SpecialEntity();
            IEnumerable<SearchSpecialEntityModel> result = new List<SearchSpecialEntityModel>();
            SE.Id = request.Id;
            SE.OrderNumber = request.OrderNumber;
            SE.SpecialEntityTypeId = request.SpecialEntityTypeId;
            SE.YearId = request.YearId;
            SE.CandidateId = request.CandidateId;
            SE.OrganizationId = request.OrganizationId;
            SE.DepartmentName = request.DepartmentName;
            SE.MaktubNumber = request.MaktubNumber;
            SE.Date = request.Date;
            SE.Refrence = request.Refrence;
            SE.Discription = request.Discription;
            SE.ShoraName = request.ShoraName;
            if (request.Id == 0)
            {
                SE.ModifiedBy = "";
                SE.ModifiedOn = DateTime.Now;
                SE.CreatedBy = CurrentUserId;
                SE.CreatedOn = DateTime.Now;
                context.SpecialEntities.Add(SE);
            }
            else
            {
                SE.ModifiedBy += "," + CurrentUserId; ;
                SE.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchSpecialEntityQuery() { Id = SE.Id,OrganizationId=SE.OrganizationId,YearId=SE.YearId });
            return result.ToList();
        }
    }
}
