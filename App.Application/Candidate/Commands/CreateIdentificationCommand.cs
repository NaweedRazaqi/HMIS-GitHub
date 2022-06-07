using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateIdentificationCommand : IRequest<List<SearchIdentificationModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int PassportNo { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime ExpairyDate { get; set; }
        public string Remarks { get; set; }
        public string NationalId { get; set; }
        public int? PassportTypeId { get; set; }

    }
    public class CreateIdentificationCommandHandler : IRequestHandler<CreateIdentificationCommand, List<SearchIdentificationModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateIdentificationCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchIdentificationModel>> Handle(CreateIdentificationCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();

            DateTime start = DateTime.Now;
            DateTime end = request.ExpairyDate.Date;
            end = end.AddMonths(-8);
            if (start >= end)
            {
                throw new BusinessRulesException("تاریخ پاسپورت کافی نیست  پاسپورت شما حد اقل شش ماه وقت داشته باشد.");
            }

            var P = request.Id != 0 ? context.Passports.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Passport();
            IEnumerable<SearchIdentificationModel> result = new List<SearchIdentificationModel>();
            P.Id = request.Id;
            P.CandidateId = request.CandidateId;
            P.PassportNo = request.PassportNo;
            P.Remarks = request.Remarks;
            P.IssueDate = request.IssueDate;
            P.ExpairyDate = request.ExpairyDate;
            P.PassportTypeId = request.PassportTypeId;
            P.NationalId = request.NationalId;

            if (request.Id == 0)
            {
                P.ModifiedBy = "";
                P.ModifiedOn = DateTime.Now;
                P.CreatedBy = CurrentUserId;
                P.CreatedOn = DateTime.Now;
                context.Passports.Add(P);
            }
            else
            {
                P.ModifiedBy += "," + CurrentUserId; ;
                P.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchIdentificationQuery() { Id = P.Id });
            return result.ToList();

        }
    }
}
