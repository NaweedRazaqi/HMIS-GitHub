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
    public class GetJobTitleQuery : IRequest<List<SearchJobTitleModel>>
    {
        public int? Id { get; set; }
        public string Jobtitle { get; set; }
        public bool ParentOnly { get; set; } = false;
    }
    public class GetJobTitleQueryHandler : IRequestHandler<GetJobTitleQuery, List<SearchJobTitleModel>>
    {
        private AppDbContext Context { get; set; }
        public GetJobTitleQueryHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<SearchJobTitleModel>> Handle(GetJobTitleQuery request, CancellationToken cancellationToken)
        {
            List<SearchJobTitleModel> list = new List<SearchJobTitleModel>();

            var query = Context.JobTitles.AsQueryable();
            if (request.Id.HasValue)
            {
                query = query.Where(JT => JT.Id == request.Id);
            }
            if (request.Jobtitle !=null)
            {
                query = query.Where(JT => JT.Title == request.Jobtitle);
            }

            list = await (from o in query
                          select new SearchJobTitleModel
                          {
                              Id = o.Id,
                              Title=o.Title,
                              Dari=o.Dari,
                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
