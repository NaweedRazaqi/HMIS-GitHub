using App.Domain.Entity.look;
using System;
using System.Collections.Generic;

namespace App.Domain.Entity.prf
{
    public partial class TicketInfo
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int AirLineId { get; set; }
        public DateTime? BookingDate { get; set; }
        public int FlightNo { get; set; }
        public int TicketNo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int DepartureProvincesId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int YearId { get; set; }
        public int ArrivalProvincesId { get; set; }
        public int? TicketCommission { get; set; }
        public virtual Airline AirLine { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Year Year { get; set; }
    }
}
