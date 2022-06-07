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
    public class GetEducationdegreeList: IRequest<List<EducationdegreeModel>>
    {
        public int? Id { get; set; }
    }
    public class GetEducationListHandler : IRequestHandler<GetEducationdegreeList, List<EducationdegreeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetEducationListHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<EducationdegreeModel>> Handle(GetEducationdegreeList request, CancellationToken cancellationToken)
        {
            List<EducationdegreeModel> list = new List<EducationdegreeModel>();

            var query = Context.Educationdegrees.AsQueryable();
            if (request.Id != null)
            {
                query = query.Where(o => o.Id == request.Id);
            }

            list = await (from o in query
                          select new EducationdegreeModel
                          {
                              Id = o.Id,
                              Name=o.Name,
                              

                          }).ToListAsync(cancellationToken);
            return list;
        }
    }
}
