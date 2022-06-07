using App.Application.Candidate.Models;
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

namespace App.Application.Candidate.Queries
{
    public class SearchVisaInfoQuery : IRequest<IEnumerable<SearchVisaInfoModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? StayDays { get; set; }
        public string VisaNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpairyDate { get; set; }
    }
    public class SearchVisaInfoQueryHandler : IRequestHandler<SearchVisaInfoQuery, IEnumerable<SearchVisaInfoModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchVisaInfoQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchVisaInfoModel>> Handle(SearchVisaInfoQuery request, CancellationToken cancellationToken)
        {
            var query = context.VisaInfos.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.StayDays != null)
            {
                query = query.Where(e => e.StayDays == request.StayDays);
            }
            if (request.IssueDate != null)
            {
                query = query.Where(e => e.IssueDate == request.IssueDate);
            }
            if (request.ExpairyDate != null)
            {
                query = query.Where(e => e.ExpairyDate == request.ExpairyDate);
            }
            if(!String.IsNullOrEmpty(request.VisaNo))
            {
                query = query.Where(e => e.VisaNo == request.VisaNo);
            }
            return await query.Select(p => new SearchVisaInfoModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                IssueDate = p.IssueDate,
                ExpairyDate = p.ExpairyDate,
                IssueDateShamsi = PersianDate.Convert(p.IssueDate).DateString,
                ExpairyDateShamsi = PersianDate.Convert(p.ExpairyDate).DateString,
                StayDays = p.StayDays,
                VisaNo = p.VisaNo,
                VisaTypeId = p.VisaType.Id,
                VisaTypeName = p.VisaType.Name

            }).ToListAsync();
        }
    }
}
