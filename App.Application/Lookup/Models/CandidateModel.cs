using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Lookup.Models
{
    public class CandidateModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
    }
}
