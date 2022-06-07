using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using App.Application.Nazim.Command;
using App.Application.Nazim.Models;
using App.Application.Nazim.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Clean.UI.Pages.Nazam
{
  
        public class NazemExperienceModel : BasePage
        {

        public async Task OnGetAsync([FromRoute] int id)
        {

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));
        }



        public async Task<IActionResult> OnPostSearch([FromBody] SearchNazemExperience query)
        {
            var result = new JsonResult(null);
            try
            {

                IEnumerable<SearchNazemExperienceModel> SaveResult = new List<SearchNazemExperienceModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateNazemExperience command)
        {
            try
            {
                IEnumerable<SearchNazemExperienceModel> SaveResult = new List<SearchNazemExperienceModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "تجربه ناظم  موفقانه ثبت گردید",
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
