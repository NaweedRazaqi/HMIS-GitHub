using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Finance.Commands;
using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Finance
{
    public class MobileCard:BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfMutamid = new List<SelectListItem>();
            var Mutamid = await Mediator.Send(new GetMutamidList());
            Mutamid.ForEach(e => ListOfMutamid.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));
           
        }

        public async Task<IActionResult> OnPostSave([FromBody] CreateMobileCardCommand command)
        {
            try
            {
                IEnumerable<SearchMobileCardModel> SaveResult = new List<SearchMobileCardModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "موفقانه ثبت گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }

        public async Task<IActionResult> OnPostSearch([FromBody] SearchMobileCardQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchMobileCardModel> SaveResult = new List<SearchMobileCardModel>();
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