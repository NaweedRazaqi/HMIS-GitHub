using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchNazamToMosqueModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int MosqueId { get; set; }
        public string MosqueName { get; set; }
        public string LocationText { get; set; }
        public int? LocationId { get; set; }
        public int? TrainingTime { get; set; }
      
    }
}
