using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class SearchTicketInfoQuery : IRequest<IEnumerable<SearchTicketInfoModel>>
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? AirLineId { get; set; }
        public int? FlightNo { get; set; }
        public int? TicketNo { get; set; }
    }
    public class SearchTicketInfoQueryHandler : IRequestHandler<SearchTicketInfoQuery, IEnumerable<SearchTicketInfoModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchTicketInfoQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchTicketInfoModel>> Handle(SearchTicketInfoQuery request, CancellationToken cancellationToken)
        {
            var query = context.TicketInfos.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != null)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.AirLineId != null)
            {
                query = query.Where(e => e.AirLineId == request.AirLineId);
            }
            if (request.FlightNo != null)
            {
                query = query.Where(e => e.FlightNo == request.FlightNo);
            }
            if (request.TicketNo != null)
            {
                query = query.Where(e => e.TicketNo == request.TicketNo);
            }
            return await query.Select(p => new SearchTicketInfoModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                YearId = p.YearId,
                YearName = p.Year.Name,
                AirLineId = p.AirLineId,
                AirLineName = p.AirLine.Dari,
                ArrivalProvincesId = p.ArrivalProvincesId,
                DepartureProvincesId = p.DepartureProvincesId,
                ArrivalDate = p.ArrivalDate,
                ArrivalDateShamsi = PersianDate.Convert(p.ArrivalDate).DateString,
                DepartureDateShamsi = PersianDate.Convert(p.DepartureDate).DateString,
                DepartureDate = p.DepartureDate,
                TicketNo = p.TicketNo,
                FlightNo = p.FlightNo,
               TicketCommission = p.TicketCommission
            }).ToListAsync();
        }
    }
}
