using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Exam.Commands;
using App.Application.Exam.Models;
using App.Application.Exam.Queries;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Nazam.Exam
{
    public class NazamExamModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfCommitee = new List<SelectListItem>();
            var Commitee = await Mediator.Send(new GetCommiteeList());
            Commitee.ForEach(e => ListOfCommitee.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name.ToString() }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateExamCommand command)
        {
            try
            {
                IEnumerable<SearchExamModel> SaveResult = new List<SearchExamModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات امتحان موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchExamQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchExamModel> SaveResult = new List<SearchExamModel>();

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