using App.Application.Lookup.Models;
using App.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Lookup.Queries
{
    public class GetJobTitleList : IRequest<List<JobTitleModel>>
    {

        public int? OrganizationId { get; set; }
        public int? TypeID { get; set; }
        public int? ParentID { get; set; }
        public int? ID { get; set; }

    }

    public class GetJobTitleListHandler : IRequestHandler<GetJobTitleList, List<JobTitleModel>>
    {
        private AppDbContext Context { get; set; }

        public GetJobTitleListHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<JobTitleModel>> Handle(GetJobTitleList request, CancellationToken cancellationToken)
        {
            var query = Context.JobTitles.AsQueryable();
            if(request.ParentID.HasValue)
            {
                query = query.Where(L => L.ParentId == request.ParentID);
            } 
            if(request.TypeID.HasValue)
            {
                query = query.Where(L => L.TypeId == request.TypeID);
            }
           
            return await query.Select(e => new JobTitleModel
            {
                Id = e.Id,
                Title = e.Title,
                Dari = e.Dari,
                ParentId=e.ParentId,
                TypeId=e.TypeId,
                OrganizationId= e.Id
            }
           
            ).ToListAsync();
            

        }

    }

}
