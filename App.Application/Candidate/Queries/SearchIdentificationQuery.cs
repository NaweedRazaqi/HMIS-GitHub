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

namespace App.Application.Candidate.Queries
{
    public class SearchIdentificationQuery : IRequest<IEnumerable<SearchIdentificationModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? PassportNo { get; set; }
    }
    public class SearchIdentificationQueryHandler : IRequestHandler<SearchIdentificationQuery, IEnumerable<SearchIdentificationModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchIdentificationQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchIdentificationModel>> Handle(SearchIdentificationQuery request, CancellationToken cancellationToken)
        {
            var query = context.Passports.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.DocumentTypeId != null)
            {
                query = query.Where(e => e.PassportTypeId == request.DocumentTypeId);
            }
            if (request.PassportNo != null)
            {
                query = query.Where(e => e.PassportNo == request.PassportNo);
            }
            return await query.Select(p => new SearchIdentificationModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                IssueDate = p.IssueDate,
                PassportNo = p.PassportNo,
                ExpairyDate = p.ExpairyDate,
                IssueDateShamsi = PersianDate.GetFormatedString(p.IssueDate),
                ExpairyDateShamsi = PersianDate.GetFormatedString(p.ExpairyDate),
                Remarks = p.Remarks,
                PassportTypeId = p.PassportTypeId,
                PTypeText=p.PassportType.Name,
                NID = p.NationalId,
            }).ToListAsync();
        }
    }
}
