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
    public class SearchSpecialEntityQuery : IRequest<IEnumerable<SearchSpecialEntityModel>>
    {
        public int Id { get; set; }
        public int? OrderNumber { get; set; }
        public int? YearId { get; set; }
        public int? SpecialEntityTypeId { get; set; }
        public int? CandidateId { get; set; }
        public int? OrganizationId { get; set; }

    }
    public class SearchSpecialEntityQueryHandler : IRequestHandler<SearchSpecialEntityQuery, IEnumerable<SearchSpecialEntityModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchSpecialEntityQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchSpecialEntityModel>> Handle(SearchSpecialEntityQuery request, CancellationToken cancellationToken)
        {
            
            var query = context.SpecialEntities.AsQueryable();
            
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.OrderNumber != null)
            {
                query = query.Where(e => e.OrderNumber == request.OrderNumber);
            }
            if (request.YearId != null)
            {
                query = query.Where(e => e.YearId == request.YearId);
            }
            if (request.SpecialEntityTypeId != null)
            {
                query = query.Where(e => e.SpecialEntityTypeId == request.SpecialEntityTypeId);
            }
            return await query.Select(p => new SearchSpecialEntityModel
            {
                Id = p.Id,
                OrderNumber = p.OrderNumber,
                YearId = p.YearId,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                YearName = p.Year.Name,
                OrganizationId = p.OrganizationId,
                OrganizationName = p.Organization.Dari,
                SpecialEntityTypeId = p.SpecialEntityTypeId,
                SpecialEntityTypeName = p.SpecialEntityType.Dari,
                DepartmentName = p.DepartmentName,
                MaktubNumber = p.MaktubNumber,
                Date = p.Date,
                SaveDate = PersianDate.GetFormatedString(p.Date),
                Refrence = p.Refrence,
                Discription = p.Discription,
                ShoraName=p.ShoraName,
                
            }).ToListAsync();
        }


    }
}
