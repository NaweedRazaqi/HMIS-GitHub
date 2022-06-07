using App.Application.Nazim.Models;
using App.Application.Nazim.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Nazim.Command
{
    public class CreateEvaluationCommand : IRequest<List<EvcategoryModel>>
    {
        public int Id { get; set; }
        public int? Nid { get; set; }
        public int? Evid { get; set; }
        public int? MarkId { get; set; }
        public int? ZoneId { get; set; }
    }
    public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, List<EvcategoryModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateEvaluationCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }

        public async Task<List<EvcategoryModel>> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<EvcategoryModel> result = new List<EvcategoryModel>();

            var ed = request.Id != 0 ? context.Nerecords.Where(e => e.Id == request.Id).Single() : new Domain.Entity.Evaluation.Nerecords();
            int CurrentUserId = await currentUser.GetUserId();
            
            ed.Id = request.Id;
            ed.Evid = request.Evid;
            ed.Nid = request.Nid;
            ed.MarkId = request.MarkId;
            ed.ZoneId = request.ZoneId;
            if (request.Id == 0)
            {
                ed.ModifiedBy = "";
                ed.CreatedOn = DateTime.Now;
                ed.CreatedBy = CurrentUserId;
                ed.CreatedOn = DateTime.Now;
                context.Nerecords.Add(ed);
            }
            else
            {
                ed.ModifiedBy += "," + CurrentUserId;
                ed.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchCategoryQuery() { Id = ed.Id });

            return result.ToList();
        }
    }

}