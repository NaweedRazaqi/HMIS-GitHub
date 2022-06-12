using App.Application.ExamScore.Models;
using App.Application.ExamScore.Queries;
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

namespace App.Application.ExamScore.Commands
{
    public class CreateExamScoreCommand : IRequest<List<SearchExamScoreModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int? ExamResultId { get; set; }
        public int? TotalMarks { get; set; }
        public int? OralExamScore { get; set; }
        public int? WrittenExamScore { get; set; }
    }
    public class CreateExamScoreCommandHandler : IRequestHandler<CreateExamScoreCommand, List<SearchExamScoreModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateExamScoreCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchExamScoreModel>> Handle(CreateExamScoreCommand request, CancellationToken cancellationToken)
        {


            if(request.OralExamScore == null || request.WrittenExamScore == null)
            {
                throw new BusinessRulesException("لطفا نمره تحریری و تقری ناظم را درج نمایید.");
            }

            int? totalscore = 0;
            totalscore = request.OralExamScore + request.WrittenExamScore;

            var examresult = 0;

            if(totalscore >= 50 && totalscore <= 100)
            {
                examresult = 1;
            }
            else if(totalscore >= 10 && totalscore <= 49)
            {
                examresult = 2;
            }

            int CurrentUserId = await currentUser.GetUserId();
            var ExamScore = request.Id != 0 ? context.ExamScores.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.ExamScore();
            IEnumerable<SearchExamScoreModel> result = new List<SearchExamScoreModel>();
            ExamScore.Id = request.Id;
            ExamScore.CandidateId = request.CandidateId;
            ExamScore.ExamResultId = examresult;
            ExamScore.OralExamScore = request.OralExamScore;
            ExamScore.WrittenExamScore = request.WrittenExamScore;
            ExamScore.TotalMarks = (int)totalscore;

             
            if (request.Id == 0)
            {
                ExamScore.ModifiedBy = "";
                ExamScore.ModifiedOn = DateTime.Now;
                ExamScore.CreatedBy = CurrentUserId;
                ExamScore.CreatedOn = DateTime.Now;
                context.ExamScores.Add(ExamScore);
            }
            else
            {
                ExamScore.ModifiedBy += "," + CurrentUserId; ;
                ExamScore.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchExamScoreQuery() { Id = ExamScore.Id });
            return result.ToList();
        }
    }
}
