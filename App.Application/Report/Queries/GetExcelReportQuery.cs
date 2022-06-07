using App.Application.Report.Models;
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

namespace App.Application.Report.Queries
{
    public class GetExcelReportQuery : IRequest<IEnumerable<EXcelReportModel>>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public int? ArcheiveNo { get; set; }
        public string Gender { get; set; }
        public string CurrentProvince { get; set; }
        public string CurrentDistricts { get; set; }
        public string PerminantProvince { get; set; }
        public string PerminantDistricts { get; set; }
        public string Religion { get; set; }
        public string CandidateType { get; set; }
        public string MahramFirstName { get; set; }
        public string MahramLastName { get; set; }
    }
    public class GetExcelReportQueryHandler : IRequestHandler<GetExcelReportQuery, IEnumerable<EXcelReportModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public GetExcelReportQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }

        public async Task<IEnumerable<EXcelReportModel>> Handle(GetExcelReportQuery request, CancellationToken cancellationToken)
        {
            var query = context.ExecelReports.AsQueryable();


            if (request.Id.HasValue)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(e => e.FirstName == request.FirstName);
            }
            if (!String.IsNullOrEmpty(request.LastName))
            {
                query = query.Where(e => e.LastName == request.LastName);
            }
           
            return await query.Select(p => new EXcelReportModel
            {
                Id=p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FatherName = p.FatherName,
                GrandFatherName = p.GrandFatherName,
                ArcheiveNo = p.ArcheiveNo,
                Gender = p.Gender,
                PerminantProvince = p.PerminantProvince,
                PerminantDistricts = p.PerminantDistricts,
                CurrentProvince = p.CurrentProvince,
                CurrentDistricts = p.CurrentDistricts,
                Religion = p.Religion,
                CandidateType = p.CandidateType,
                MahramFirstName = p.MahramFirstName,
                MahramLastName = p.MahramLastName
            }).ToListAsync();

        }
    }
}
