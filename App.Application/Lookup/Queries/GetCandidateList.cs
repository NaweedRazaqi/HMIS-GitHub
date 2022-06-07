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
    public class GetCandidateList : IRequest<List<CandidateModel>>
    {
        public int ID { get; set; }
        public string Flag { get; set; }
    }
    public class GetCandidateListHandler : IRequestHandler<GetCandidateList, List<CandidateModel>>
    {
        private AppDbContext Context { get; set; }
        public GetCandidateListHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<CandidateModel>> Handle(GetCandidateList request, CancellationToken cancellationToken)
        {
            var query = Context.Candidates.AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }
            if(request.Flag == "Candidate")
            {
                query = query.Where(e => e.CandidateTypeId == 1);
            }
            if(request.Flag == "Nazam")
            {
                query = query.Where(e => e.CandidateTypeId == 2);
            }
            return await query.Select(e => new CandidateModel
            {
                ID = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.FatherName,
                FullName  = e.FirstName + " " + e.LastName + " ولد " + e.FatherName
            }).ToListAsync();
        }
    }
}
