using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Emara.Commands;
using App.Application.Emara.Models;
using App.Application.Emara.Queries;
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
using Syncfusion.EJ2.Linq;

namespace Clean.UI.Pages.Emara
{
    public class EmaraModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfEmara = new List<SelectListItem>();
            var emara = await Mediator.Send(new SearchEmaraQuery());
            emara.ForEach(e => ListOfEmara.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name + ' ' 
                + e.EmaraZoneName + ' ' + e.EmaraTypeName + ' ' }));
            
           
            ListOfPersianYears = new List<SelectListItem>();
            var Year= await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfLocations = new List<SelectListItem>();
            var Location = await Mediator.Send(new GetLocationList { ID = 1066 });
            Location.ForEach(e => ListOfLocations.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari.ToString() }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateHajitoEmaraCommand command)
        {
            try
            {
                IEnumerable<HajjiToEmaraSearchModel> SaveResult = new List<HajjiToEmaraSearchModel>();
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
        public async Task<IActionResult> OnPostSearch([FromBody] SearchHajitoEmaraQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<HajjiToEmaraSearchModel> SaveResult = new List<HajjiToEmaraSearchModel>();

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