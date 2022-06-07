using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Views
{
    public class PrintInstallmentModel
    {
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Province { get; set; }
        public string Destricts { get; set; }
        public string Vilege { get; set; }
        public string NationalId { get; set; }
        public string NIDText { get; set; }
        public string Religion { get; set; }
        public string Code { get; set; }

    }
}
