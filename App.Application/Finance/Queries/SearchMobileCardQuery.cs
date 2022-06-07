using App.Application.Finance.Models;
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

namespace App.Application.Finance.Queries
{
    public class SearchMobileCardQuery : IRequest<IEnumerable<SearchMobileCardModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string JobTitle { get; set; }
    }
    public class SearchMobileCardQueryHandler : IRequestHandler<SearchMobileCardQuery, IEnumerable<SearchMobileCardModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchMobileCardQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchMobileCardModel>> Handle(SearchMobileCardQuery request, CancellationToken cancellationToken)
        {
            var query = context.MobileCards.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.Name))
            {
                query = query.Where(e => e.Name == request.Name);
            }
            if (!String.IsNullOrEmpty(request.FatherName))
            {
                query = query.Where(e => e.FatherName == request.FatherName);
            }
            if (!String.IsNullOrEmpty(request.JobTitle))
            {
                query = query.Where(e => e.JobTitle == request.JobTitle);
            }
            return await query.Select(p => new SearchMobileCardModel
            {
               Id = p.Id,
               Name  = p.Name,
               FatherName = p.FatherName,
               JobTitle = p.JobTitle,
               Date = p.Date,
               SpentFor = p.SpentFor,
               MutamidId = p.MutamidId,
               MutamidName = p.Mutamid.Name,
               AreaToContact = p.AreaToContact,
               NumberOfHaji = p.NumberOfHaji,
               CostPerMinute = p.CostPerMinute,
               CostPerHaji = p.CostPerHaji,
               DurationInMinutes = p.DurationInMinutes,
               TotalCost = p.TotalCost,
               TotalPayebale = p.TotalPayebale,
               RecievingPlace = p.RecievingPlace,
               Comments =  p.Comments,
            }).ToListAsync();
        }
    }
}
