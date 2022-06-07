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
    public class CreateTicketInfoCommand : IRequest<List<SearchTicketInfoModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int AirLineId { get; set; }
        public DateTime? BookingDate { get; set; }
        //public int BookingNumber { get; set; }
        public int FlightNo { get; set; }
        public int TicketNo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int DepartureProvincesId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int YearId { get; set; }
        public int ArrivalProvincesId { get; set; }
        public int? TicketCommission { get; set; }

    }
    public class CreateTicketInfoCommandHandler : IRequestHandler<CreateTicketInfoCommand, List<SearchTicketInfoModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateTicketInfoCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchTicketInfoModel>> Handle(CreateTicketInfoCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var TicketInfo = request.Id != 0 ? context.TicketInfos.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.TicketInfo();
            IEnumerable<SearchTicketInfoModel> result = new List<SearchTicketInfoModel>();
            TicketInfo.CandidateId = request.CandidateId;
            TicketInfo.AirLineId = request.AirLineId;
          //  TicketInfo.BookingDate = request.BookingDate;
            //TicketInfo.BookingNumber = request.BookingNumber;
            TicketInfo.FlightNo = request.FlightNo;
            TicketInfo.TicketNo = request.TicketNo;
            TicketInfo.DepartureDate = request.DepartureDate;
            TicketInfo.DepartureProvincesId = request.DepartureProvincesId;
            TicketInfo.ArrivalDate = request.ArrivalDate;
            TicketInfo.ArrivalProvincesId = request.ArrivalProvincesId;
            TicketInfo.YearId = request.YearId;
            TicketInfo.TicketCommission = request.TicketCommission;


            if (request.Id == 0)
            {
                TicketInfo.ModifiedBy = "";
                TicketInfo.ModifiedOn = DateTime.Now;
                TicketInfo.CreatedBy = CurrentUserId;
                TicketInfo.CreatedOn = DateTime.Now;
                context.TicketInfos.Add(TicketInfo);
            }
            else
            {
                TicketInfo.ModifiedBy += "," + CurrentUserId; ;
                TicketInfo.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchTicketInfoQuery() {  Id = TicketInfo.Id });
            return result.ToList();

        }
    }
}
