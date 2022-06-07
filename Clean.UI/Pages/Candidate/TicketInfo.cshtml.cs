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
    public class TicketInfoModel : BasePage
    {

        public async Task OnGetAsync()
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfAirLine = new List<SelectListItem>();
            var AirLine = await Mediator.Send(new GetAirLineList());
            AirLine.ForEach(e => ListOfAirLine.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfLocations = new List<SelectListItem>();
            var Location = await Mediator.Send(new GetLocationList { ParentID = null });
            Location.ForEach(e => ListOfLocations.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchTicketInfoQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchTicketInfoModel> SaveResult = new List<SearchTicketInfoModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateTicketInfoCommand command)
        {
            try
            {
                IEnumerable<SearchTicketInfoModel> SaveResult = new List<SearchTicketInfoModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات تکت موفقانه ثبت و راجستر گردید",
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