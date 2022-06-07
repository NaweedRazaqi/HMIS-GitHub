using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Candidate.Models
{
    public class SearchInstallmentModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int InstallmentTypeId { get; set; }
        public string InstallmentTypeName { get; set; }
        public DateTime Date { get; set; }
        public string DateShamsi { get; set; }
        public string DateShamsi2 { get; set; }
        public string Converteddate { get; set; }
        public int Amount { get; set; }
        public int Amount2 { get; set; }
        public int RecipetNo { get; set; }
        public int RecipetNo2 { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int CurrencyId { get; set; }
        public int? InstallmentNo { get; set; }
        public int? InstallmentNo2 { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyRate { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public string Orders { get; set; }
        public string whoisorder { get; set; }
        public string Discount { get; set; }
        public int? Discountid { get; set; }
        public int? Amountofdiscount { get; set; }
        public int? OrderId { get; set; }
        public int? OrderNumber { get; set; }
        public int? OrdererId { get; set; }

    }
}
