using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.ExamScore.Commands;
using App.Application.ExamScore.Models;
using App.Application.ExamScore.Queries;
using App.Application.Lookup.Queries;
using Clean.Persistence.Services;
using Clean.UI.Types;
using Clean.UI.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace Clean.UI.Pages.Nazam.ExamScore
{
    public class ExamScoreModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfNazamCandidate = new List<SelectListItem>();
            var Nazam = await Mediator.Send(new GetCandidateList { Flag = "Nazam"});
            Nazam.ForEach(e => ListOfNazamCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfExamResult = new List<SelectListItem>();
            var ExamResult = await Mediator.Send(new GetExamResultList());
            ExamResult.ForEach(e => ListOfExamResult.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari.ToString() }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateExamScoreCommand command)
        {
            try
            {
                IEnumerable<SearchExamScoreModel> SaveResult = new List<SearchExamScoreModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "نمرات موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchExamScoreQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchExamScoreModel> SaveResult = new List<SearchExamScoreModel>();

                SaveResult = await Mediator.Send(query);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                result.Value = new UIResult
                {
                    Status = UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message + " \n StackTrace : " + ex.StackTrace,
                    Data = null
                };
            }
            return result;
        }
    }
}