using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchTicketInfoModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int AirLineId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingDateShamsi { get; set; }
        public int BookingNumber { get; set; }
        public int FlightNo { get; set; }
        public int TicketNo { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureDateShamsi { get; set; }
        public int DepartureProvincesId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ArrivalDateShamsi { get; set; }
        public int YearId { get; set; }
        public int ArrivalProvincesId { get; set; }
        public string ArrivalProvincesName { get; set; }
        public int? YearName { get; set; }
        public string AirLineName { get; set; }
        public string CandidateName { get; set; }
        public int? TicketCommission { get; set; }
    }
}
