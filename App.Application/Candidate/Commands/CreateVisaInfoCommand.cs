using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
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
    public class CreateVisaInfoCommand : IRequest<List<SearchVisaInfoModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpairyDate { get; set; }
        //public int StayDays { get; set; }
        public int? VisaTypeId { get; set; }
        public string VisaNo { get; set; }

    }
    public class CreateVisaInfoCommandHandler : IRequestHandler<CreateVisaInfoCommand, List<SearchVisaInfoModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateVisaInfoCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchVisaInfoModel>> Handle(CreateVisaInfoCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var VisaInfo = request.Id != 0 ? context.VisaInfos.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.VisaInfo();
            IEnumerable<SearchVisaInfoModel> result = new List<SearchVisaInfoModel>();
            VisaInfo.Id = request.Id;
            VisaInfo.CandidateId = request.CandidateId;
            VisaInfo.IssueDate = request.IssueDate;
            VisaInfo.ExpairyDate = request.ExpairyDate;
            VisaInfo.VisaNo = request.VisaNo;
            VisaInfo.VisaTypeId = request.VisaTypeId;

            if (request.Id == 0)
            {
                VisaInfo.ModifiedBy = "";
                VisaInfo.ModifiedOn = DateTime.Now;
                VisaInfo.CreatedBy = CurrentUserId;
                VisaInfo.CreatedOn = DateTime.Now;
                context.VisaInfos.Add(VisaInfo);
            }
            else
            {
                VisaInfo.ModifiedBy += "," + CurrentUserId; ;
                VisaInfo.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchVisaInfoQuery() { Id = VisaInfo.Id });
            return result.ToList();

        }
    }
}
