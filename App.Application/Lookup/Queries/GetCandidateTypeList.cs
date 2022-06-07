using App.Application.Lookup.Models;
using App.Persistence.Context;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
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
    public class GetCandidateTypeList : IRequest<List<CandidateTypeModel>>
    {
        public int ID { get; set; }
        public string Flag { get; set; }
    }
    public class GetCandidateTypeListHandler : IRequestHandler<GetCandidateTypeList, List<CandidateTypeModel>>
    {
        private AppDbContext Context { get; set; }
        private ICurrentUser User;
        private AppIdentityDbContext IDContext;
        public GetCandidateTypeListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<CandidateTypeModel>> Handle(GetCandidateTypeList request, CancellationToken cancellationToken)
        {
            var query = Context.CandidateTypes.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }
            if (request.Flag=="Haji")
            {
                query = query.Where(e => e.Id == 1 );
            }
            if (request.Flag=="Nazim")
            {
                query = query.Where(e => e.Id == 2 );
            } 
            return await query.Select(e => new CandidateTypeModel
            {
                ID = e.Id,
                Name = e.Name,
                Dari = e.Dari
            }).ToListAsync();
        }
    }
}
