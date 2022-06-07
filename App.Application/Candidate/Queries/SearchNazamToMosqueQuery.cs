using App.Application.Candidate.Models;
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

namespace App.Application.Candidate.Queries
{
    public class SearchNazamToMosqueQuery : IRequest<IEnumerable<SearchNazamToMosqueModel>>
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }
        public int? MosqueId { get; set; }
    }
    public class SearchNazamToMosqueQueryHandler : IRequestHandler<SearchNazamToMosqueQuery, IEnumerable<SearchNazamToMosqueModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchNazamToMosqueQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchNazamToMosqueModel>> Handle(SearchNazamToMosqueQuery request, CancellationToken cancellationToken)
        {
            var query = context.NazamToMosques.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != 0)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            //if (request.MosqueId != 0)
            //{
            //    query = query.Where(e => e.MosqueId == request.MosqueId);
            //}
            return await query.Select(p => new SearchNazamToMosqueModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                MosqueId = p.MosqueId,
                MosqueName = p.Mosque.Name,
                TrainingTime = p.TrainingTime,
                LocationId = p.LocationId,
                LocationText = p.Location.Dari
            }).ToListAsync();
        }
    }
}
