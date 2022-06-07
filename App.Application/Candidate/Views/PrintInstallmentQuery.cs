using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Service;
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

namespace App.Application.Candidate.Views
{
    public class PrintInstallmentQuery : IRequest<IEnumerable<PrintInstallmentModel>>
    {
        
        public string FirstName { get; set; }
        public string fatherName { get; set; }
    }
    public class PrintInstallmentQueryHandler : IRequestHandler<PrintInstallmentQuery, IEnumerable<PrintInstallmentModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public PrintInstallmentQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<PrintInstallmentModel>> Handle(PrintInstallmentQuery request, CancellationToken cancellationToken)
        {
            var query = context.view.AsQueryable();
            if (request.FirstName != null)
            {
                query = query.Where(e => e.FirstName == request.FirstName);
            }
            if (request.fatherName != null)
            {
                query = query.Where(e => e.FatherName == request.fatherName);
            }
            return await query.Select(p => new PrintInstallmentModel
            { 
                FirstName = p.FirstName,
                FatherName = p.FatherName,
               GrandFatherName=p.GrandFatherName,
               Province=p.Province,
               Destricts=p.Destricts,
               Vilege=p.Vilege,
               NationalId=p.NationalId,
                NIDText = NationalIDReader.ConvertJSONToString(p.NationalId,"").ToString() ?? "درج نگردیده",
                Religion =p.Religion,
               Code=p.Code
            }).ToListAsync();
        }
    }
}
