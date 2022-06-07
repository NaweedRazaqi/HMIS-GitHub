
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Candidate.Views;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;

namespace Clean.UI.Pages.Candidate.Prints
{
    public class PrintformModel : BasePage
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
        //installment
        public string DateShamsi { get; set; }
        public int Amount { get; set; }
        public int RecipetNo { get; set; }
        public int? InstallmentNo { get; set; }
        //2nd installment
        public string DateShamsi2 { get; set; }
        public int Amount2 { get; set; }
        public int RecipetNo2 { get; set; }
        public int? InstallmentNo2 { get; set; }
        public async Task OnGet([FromQuery] int recordId)
        {
            var cand = await this.Mediator.Send(new PrintInstallmentQuery { });
            var clist = cand.FirstOrDefault();
            if (!cand.Any())
            {
                FirstName = "";
                FatherName = "";
                GrandFatherName ="";
                Province = "";
                Destricts = "";
                Vilege = "";
                NIDText = "";
                Religion = "";
                Code = "";
            }              
            if (cand.Any())
            {
                FirstName = clist.FirstName;
                FatherName = clist.FatherName;
                GrandFatherName = clist.GrandFatherName;
                Province = clist.Province;
                Destricts = clist.Destricts;
                Vilege = clist.Vilege;
                NIDText = clist.NationalId;
                Religion = clist.Religion;
                Code = clist.Code;
            }
            //installments
            var installment = await this.Mediator.Send(new SearchInstallmentQuery { CandidateId = recordId });
            var inst = installment.FirstOrDefault();
            if (!installment.Any())
            {
                Amount = 0;
                RecipetNo = 0;
                InstallmentNo = 0;
                DateShamsi = "معلومات موجود نیست";
            }
            if (installment.Any())
            {
                Amount = inst.Amount;
                RecipetNo = inst.RecipetNo;
                InstallmentNo = inst.InstallmentNo;
                DateShamsi = inst.DateShamsi;
            }
            //installments
            var installment2 = await this.Mediator.Send(new SearchInstallmentQuery { CandidateId = recordId });
            var inst2 = installment2.FirstOrDefault();
            if (!installment.Any())
            {
                Amount2 = 0;
                RecipetNo2= 0;
                InstallmentNo2 = 0;
                DateShamsi2 = "معلومات موجود نیست";
            }
            if (installment.Any())
            {
                Amount2 = inst.Amount2;
                RecipetNo2 = inst.RecipetNo2;
                InstallmentNo2 = inst.InstallmentNo2;
                DateShamsi2 = inst.DateShamsi2;
               
            }

        }
    }
   
}
