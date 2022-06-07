using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace App.Application.Candidate.Queries
{
    public class SearchEducationQuery : IRequest<IEnumerable<SearchEducationModel>>
    {
        public long Id { get; set; }
        public int CandidateId { get; set; }
    }
    public class SearchEducationQueryHandler : IRequestHandler<SearchEducationQuery, IEnumerable<SearchEducationModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;
        private AppIdentityDbContext IDContext;
        public SearchEducationQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }

        public async Task<IEnumerable<SearchEducationModel>> Handle(SearchEducationQuery request, CancellationToken cancellationToken)
        {
            var query = context.Educations.AsQueryable();

            if (request.Id==0 && request.CandidateId==0)
            {
                return new List<SearchEducationModel>();
            }
            if (request.Id != 0)
            {
                query = query.Where(C => C.Id == request.Id);
            }
            if (request.CandidateId != 0)
            {
                query = query.Where(C => C.CandidateId == request.CandidateId);
            }

            return await query.Select(e => new SearchEducationModel
            {
                CandidateId = e.CandidateId,
                StartDate = e.StartDate,
                Startdates = PersianDate.GetFormatedString(e.StartDate),
                Enddates= PersianDate.GetFormatedString(e.EndDate),
                EndDate = e.EndDate,
                CountryId = e.CountryId,
                CountryName=e.Country.Dari,
                FieldofstudyId = e.FieldofstudyId,
                 StudyTypeId = e.StudyTypeId,
                Fieldofstudy=e.Fieldofstudy.Text,
                DegreeId = e.DegreeId,
                Degree=e.Degree.Name,
                University = e.University.Name,
                Id=e.Id,
                UniversityId = e.UniversityId
            }).ToListAsync();
        }
    }
}