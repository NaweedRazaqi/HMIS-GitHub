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
    public class StudyFieldList : IRequest<List<FieldOfStudyModel>>
    {
        public int? Id { get; set; }

    }
    public class StudyFieldListHandler : IRequestHandler<StudyFieldList, List<FieldOfStudyModel>>
    {
        private AppDbContext Context { get; set; }
        public StudyFieldListHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<FieldOfStudyModel>> Handle(StudyFieldList request, CancellationToken cancellationToken)
        {
            var bq = Context.Studyfields.AsQueryable();
            if (request.Id.HasValue)
            {
                bq = bq.Where(e => e.Id == request.Id);
            }

            return await bq.Select(e => new FieldOfStudyModel
            {
                Id = e.Id,
                Text = e.Text,
                

            }).ToListAsync();
        }
    }
}