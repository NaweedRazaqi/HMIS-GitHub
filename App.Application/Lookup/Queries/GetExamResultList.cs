using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
    public class GetExamResultList : IRequest<List<ExamResultModel>>
    {
        public int ID { get; set; }
    }
    public class GetExamResultListHandler : IRequestHandler<GetExamResultList, List<ExamResultModel>>
    {
        private AppDbContext Context { get; set; }
        public GetExamResultListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<ExamResultModel>> Handle(GetExamResultList request, CancellationToken cancellationToken)
        {
            var query = Context.ExamResults.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new ExamResultModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari,
            }).ToListAsync();
        }
    }
}
