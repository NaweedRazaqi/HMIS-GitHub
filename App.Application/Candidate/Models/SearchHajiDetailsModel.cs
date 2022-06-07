using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchHajiDetailsModel
    {

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string Genders { get; set; }
        public string Relegions { get; set; }
        public string Ctype { get; set; }
        public int? Mahramid { get; set; }
        public string Mahramname { get; set; }
        public string Mahramlast { get; set; }
    }
}
