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
    public class GetCommiteeList : IRequest<List<CommiteeModel>>
    {
        public int ID { get; set; }
    }
    public class GetCommiteeListHandler : IRequestHandler<GetCommiteeList, List<CommiteeModel>>
    {
        private AppDbContext Context { get; set; }
        public GetCommiteeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<CommiteeModel>> Handle(GetCommiteeList request, CancellationToken cancellationToken)
        {
            var query = Context.Commitees.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }

            return await query.Select(e => new CommiteeModel
            {
                ID = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
