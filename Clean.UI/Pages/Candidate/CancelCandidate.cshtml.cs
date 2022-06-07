using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Candidate
{
    public class CancelCandidateModel : BasePage
    {
        public Boolean ShowSheen12Button = true;
        public int ScreenID = 46;

        public async Task OnGetAsync()
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchCancelCandidateQuery query)
        {
            var result = new JsonResult(null);
            try
            {

                IEnumerable<SearchCancelCandidateModel> SaveResult = new List<SearchCancelCandidateModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateCancelCandidateCommand command)
        {
            //command.HajjProcessId = 2;
            try
            {
                IEnumerable<SearchCancelCandidateModel> SaveResult = new List<SearchCancelCandidateModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()

                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "حاجی موفقانه لغو گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
    }
}