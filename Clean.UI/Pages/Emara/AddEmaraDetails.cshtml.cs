using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Emara.Commands;
using App.Application.Emara.Models;
using App.Application.Emara.Queries;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Emara
{
    public class AddEmaraDetailsModel : BasePage
    {
        public async Task OnGetAsync([FromRoute] int id)
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfLocations = new List<SelectListItem>();
            var Location = await Mediator.Send(new GetLocationList { ID = 1066 });
            Location.ForEach(e => ListOfLocations.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari.ToString() }));

            ListEmaraType = new List<SelectListItem>();
            var emara = await Mediator.Send(new GetEmaraType());
            emara.ForEach(e => ListEmaraType.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));
            ListEmaraZoneType = new List<SelectListItem>();
            var zone = await Mediator.Send(new GetEmaraZoneType());
            zone.ForEach(e => ListEmaraZoneType.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));
        }


        public async Task<IActionResult> OnPostSave([FromBody] CreateEmaraCommand command)
        {
            try
            {
                IEnumerable<SearchEmaraModel> SaveResult = new List<SearchEmaraModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "معلومات اعماره موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchEmaraQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchEmaraModel> SaveResult = new List<SearchEmaraModel>();

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
