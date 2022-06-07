using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Models;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Candidate
{
    public class PassportModel : BasePage
    {

        public async Task OnGetAsync([FromRoute]int id)
        {
            ListOfPassportType = new List<SelectListItem>();
            var ps = await Mediator.Send(new GetPassportTypeList());
            ps.ForEach(e => ListOfPassportType.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));

        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchIdentificationQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchIdentificationModel> SaveResult = new List<SearchIdentificationModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateIdentificationCommand command)
        {
            try
            {
                IEnumerable<SearchIdentificationModel> SaveResult = new List<SearchIdentificationModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "اسناد هویت موفقانه ثبت و راجستر گردید",
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