using App.Application.ExamScore.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.ExamScore.Queries
{
    public class SearchExamScoreQuery : IRequest<IEnumerable<SearchExamScoreModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? Marks { get; set; }
        public int? ExamResultId { get; set; }
    }
    public class SearchExamScoreQueryHandler : IRequestHandler<SearchExamScoreQuery, IEnumerable<SearchExamScoreModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchExamScoreQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchExamScoreModel>> Handle(SearchExamScoreQuery request, CancellationToken cancellationToken)
        {
            var query = context.ExamScores.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            //if (request.Marks != null)
            //{
            //    query = query.Where(e => e.Marks == request.Marks);
            //}
            if (request.ExamResultId != null)
            {
                query = query.Where(e => e.ExamResultId == request.ExamResultId);
            }
            return await query.Select(p => new SearchExamScoreModel
            {
                Id = p.Id,
                NazamName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                CandidateId = p.CandidateId,
                TotalMarks = p.TotalMarks,
                ExamResultId = p.ExamResultId,
                ExamResultName = p.ExamResult.Dari,
                OralExamScore = p.OralExamScore,
                WrittenExamScore = p.WrittenExamScore

            }).ToListAsync();
        }
    }
}
