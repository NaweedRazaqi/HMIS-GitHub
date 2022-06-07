using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchCandidateStatusModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int StatusTypeId { get; set; }
        public string StatusTypeName { get; set; }
        public int CprovincesId { get; set; }
        public string ProvinceName { get; set; }
        public string RoomNo { get; set; }
        public string Remarks { get; set; }
    }
}
