using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CandidateStatusModel : BasePage
    {

        public async Task OnGetAsync()
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfProvinces = new List<SelectListItem>();
            var Province = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Province.ForEach(e => ListOfProvinces.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfStatusType = new List<SelectListItem>();
            var Status = await Mediator.Send(new GetStatusTypeList());
            Status.ForEach(e => ListOfStatusType.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchCandidateStatusQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchCandidateStatusModel> SaveResult = new List<SearchCandidateStatusModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateCandidateStatusCommand command)
        {
            try
            {
                IEnumerable<SearchCandidateStatusModel> SaveResult = new List<SearchCandidateStatusModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "حالت حاجی موفقانه ثبت و راجستر گردید",
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