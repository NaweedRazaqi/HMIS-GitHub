using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchCancelCandidateModel
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string Remarks { get; set; }
        public string CancelReasons { get; set; }
    }
}
