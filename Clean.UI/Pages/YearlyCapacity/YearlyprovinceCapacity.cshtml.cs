using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Lookup.Queries;
using App.Application.YearlyCapacity.Commands;
using App.Application.YearlyCapacity.Models;
using App.Application.YearlyCapacity.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Clean.UI.Pages.YearlyCapacity
{
    public class YearlyprovinceCapacityModel : BasePage
    {
        public async Task OnGetAsync([FromRoute] int id)
        {

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfProvinces = new List<SelectListItem>();
            var Province = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Province.ForEach(e => ListOfProvinces.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfCandidateTypes = new List<SelectListItem>();
            var candidatetype = await Mediator.Send(new GetCandidateTypeList());
            candidatetype.ForEach(e => ListOfCandidateTypes.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateProvinceCapacityCommand command)
        {
            try
            {
                IEnumerable<SearchProvinceCapacityModel> SaveResult = new List<SearchProvinceCapacityModel>();
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
        public async Task<IActionResult> OnPostSearch([FromBody] SearchProvinceCapacityQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchProvinceCapacityModel> SaveResult = new List<SearchProvinceCapacityModel>();

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