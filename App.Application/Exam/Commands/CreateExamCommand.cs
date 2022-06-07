using App.Application.Exam.Models;
using App.Application.Exam.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Exam.Commands
{
    public class CreateExamCommand : IRequest<List<SearchExamModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Date { get; set; }
        public int CommiteeId { get; set; }
    }
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, List<SearchExamModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateExamCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchExamModel>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Exam = request.Id != 0 ? context.Exams.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Exam();
            IEnumerable<SearchExamModel> result = new List<SearchExamModel>();
            Exam.Id = request.Id;
            Exam.CommiteeId = request.CommiteeId;
            Exam.Date = request.Date;


            if (request.Id == 0)
            {
                Exam.ModifiedBy = "";
                Exam.ModifiedOn = DateTime.Now;
                Exam.CreatedBy = CurrentUserId;
                Exam.CreatedOn = DateTime.Now;
                context.Exams.Add(Exam);
            }
            else
            {
                Exam.ModifiedBy += "," + CurrentUserId; ;
                Exam.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchExamQuery() { Id = Exam.Id });
            return result.ToList();
        }
    }
}
