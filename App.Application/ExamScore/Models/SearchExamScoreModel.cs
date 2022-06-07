using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.ExamScore.Models
{
    public class SearchExamScoreModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public int Marks { get; set; }
        public int ExamResultId { get; set; }
        public string ExamResultName { get; set; }
        public string NazamName { get; set; }
        public int TotalMarks { get; set; }
        public int? OralExamScore { get; set; }
        public int? WrittenExamScore { get; set; }
    }
}
