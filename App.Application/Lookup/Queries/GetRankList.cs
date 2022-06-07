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

    public class GetRankList : IRequest<List<RankModel>>
    {
        public int Id { get; set; }
    }
    public class GetRankListHandler : IRequestHandler<GetRankList, List<RankModel>>
    {
        private AppDbContext Context { get; set; }
        public GetRankListHandler(AppDbContext context)
        {
            Context = context;
        }

        public async Task<List<RankModel>> Handle(GetRankList request, CancellationToken cancellationToken)
        {
            var query = Context.Ranks.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }

            return await query.Select(e => new RankModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToListAsync();
        }
    }
}
