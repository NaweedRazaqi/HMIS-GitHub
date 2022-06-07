using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Report.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Spire.Xls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.UI.Pages.ReportsToExcel
{
    public class Report : BasePage
    {

        public async Task<IActionResult> OnGet([FromBody] SearchCandidateQuery Cand)
        {
            var PrintResult = await Mediator.Send(new SearchCandidateQuery { });
            var CL = PrintResult.ToList();
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(new System.IO.FileInfo("D:\\Excel\\Reports.xlsx")))
            {
                var workSheet = package.Workbook.Worksheets[0];
                workSheet.Row(6).Height = 20;
                workSheet.Row(6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(6).Style.Font.Bold = true;
                workSheet.Cells["A6:L6"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A6:L6"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                workSheet.Cells["A6:L6"].Style.Font.Color.SetColor(ColorTranslator.FromHtml(string.Format("white")));
                //workSheet.Row(6).Style.ShrinkToFit.ToString();

                workSheet.Cells[6, 1].Value = "شماره";
                workSheet.Cells[6, 2].Value = "آی دی";
                workSheet.Cells[6, 3].Value = "اسم";
                workSheet.Cells[6, 4].Value = "تخلص";
                workSheet.Cells[6, 5].Value = "ولد";
                workSheet.Cells[6, 6].Value = "ولدیت";
                workSheet.Cells[6, 7].Value = "نوعیت کاندید";
                workSheet.Cells[6, 8].Value = "ولایت فعلی";
                workSheet.Cells[6, 9].Value = "ولسوالی فعلی";
                workSheet.Cells[6, 10].Value = "جنسیت";
                workSheet.Cells[6, 11].Value = "مذهب";
                workSheet.Cells[6, 12].Value = "شماره ارشیف";
                int recordIndex = 7;
                foreach (var Candidate in CL)
                {
                    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                    workSheet.Cells[recordIndex, 2].Value = Candidate.Id;
                    workSheet.Cells[recordIndex, 3].Value = Candidate.FirstName;
                    workSheet.Cells[recordIndex, 4].Value = Candidate.LastName;
                    workSheet.Cells[recordIndex, 5].Value = Candidate.FatherName;
                    workSheet.Cells[recordIndex, 6].Value = Candidate.GrandFatherName;
                    workSheet.Cells[recordIndex, 7].Value = Candidate.CandidateTypeName;
                    workSheet.Cells[recordIndex, 8].Value = Candidate.ProvinceName;
                    workSheet.Cells[recordIndex, 9].Value = Candidate.DestrictName;
                    workSheet.Cells[recordIndex, 10].Value = Candidate.GenderName;
                    workSheet.Cells[recordIndex, 11].Value = Candidate.ReligionName;
                    workSheet.Cells[recordIndex, 12].Value = Candidate.ArchiveNo;
                    recordIndex++;
                }

                workSheet.Cells["A6:S6"].AutoFitColumns();

                package.SaveAs(stream);

            }
            stream.Position = 0;

            string excelName = $"Reports-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.xlsx", excelName);
        }

    }
}
