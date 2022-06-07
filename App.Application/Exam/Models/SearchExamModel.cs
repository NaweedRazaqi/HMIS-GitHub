using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Exam.Models
{
    public class SearchExamModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public int CommiteeId { get; set; }
        public string CommiteeName { get; set; }
    }
}
