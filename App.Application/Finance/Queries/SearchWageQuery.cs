using App.Application.Finance.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
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
    public class SearchWageQuery : IRequest<IEnumerable<SearchWageModel>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string JobTitle { get; set; }
    }
    public class SearchWageQueryHandler : IRequestHandler<SearchWageQuery, IEnumerable<SearchWageModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchWageQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchWageModel>> Handle(SearchWageQuery request, CancellationToken cancellationToken)
        {
            var query = context.Wages.AsQueryable();
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
            return await query.Select(p => new SearchWageModel
            {
                Id = p.Id,
                Date = p.Date,
                Name = p.Name,
                FatherName = p.FatherName,
                EmployeeContractTypeId = p.EmployeeContractTypeId,
                EmployeeContractTypeName = p.EmployeeContractType.Dari,
                JobTitle = p.JobTitle,
                WorkingCommitee = p.WorkingCommitee,
                PerDayWage = p.PerDayWage,
                NoOfDays = p.NoOfDays,
                TotalWage = p.TotalWage,
                AbsentyDeduction = p.AbsentyDeduction,
                TaxDeduction = p.TaxDeduction,
                TotalPayment = p.TotalPayment,
                Comments = p.Comments,
                DateShamsi = PersianDate.Convert(p.Date).DateString
            }).ToListAsync();
        }
    }
}
