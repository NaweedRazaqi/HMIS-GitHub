using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Lookup.Queries;
using App.Application.Nazim.Command;
using App.Application.Nazim.Models;
using App.Application.Nazim.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Clean.UI.Pages.Nazam.Evaluation.EvaluationForm
{
    public class EvaluationFormModel : BasePage
    {


        public async Task OnGetAsync([FromRoute] int id)
        {

            //Marks
            Marks = new List<SelectListItem>();
            var edl = await Mediator.Send(new GetMarksQuery());
            edl.ForEach(el => Marks.Add(new SelectListItem { Value = el.Id.ToString(), Text = el.Name }));
            //Category
            Category = new List<SelectListItem>();
            var studyfield = await Mediator.Send(new GetEvCategoryQuery());
            studyfield.ForEach(sf => Category.Add(new SelectListItem { Value = sf.Id.ToString(), Text = sf.Name }));
            //Zones
            Zones = new List<SelectListItem>();
            var locations = await Mediator.Send(new GetZoneQuery());
            locations.ForEach(location => Zones.Add(new SelectListItem { Value = location.Id.ToString(), Text = location.Name }));

        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateEvaluationCommand command)
        {
            try
            {
                IEnumerable<EvcategoryModel> SaveResult = new List<EvcategoryModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchCategoryQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<EvcategoryModel> SaveResult = new List<EvcategoryModel>();
              
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