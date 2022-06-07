using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
  public  class QueueModel
    {
        public long Id { get; set; }
        public int CandidateId { get; set; }
        public int? CurrentYearsId { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? SelectedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int? GenderId { get; set; }
        public string Gender { get; set; }
        public string Years { get; set; }
        public string Religion { get; set; }
        public string Code { get; set; }


    }
}