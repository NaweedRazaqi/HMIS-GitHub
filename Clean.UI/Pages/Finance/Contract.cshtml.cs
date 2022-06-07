using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Finance.Commands;
using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Application.Lookup.Queries;
using Clean.Application.System.Queries;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Finance
{
    public class ContractModel : BasePage
    {
        public string SubScreens { get; set; }
        private string htmlTemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>";

        public async Task OnGetAsync()
        {
            ListOfLocations = new List<SelectListItem>();
            var Location = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Location.ForEach(e => ListOfLocations.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfExpenseCenters = new List<SelectListItem>();
            var ExpenseCenters = await Mediator.Send(new GetExpenseCentersList ());
            ExpenseCenters.ForEach(e => ListOfExpenseCenters.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            string Screen = EncryptionHelper.Decrypt(HttpContext.Request.Query["p"]);
            int ScreenID = Convert.ToInt32(Screen);

            try
            {
                var screens = await Mediator.Send(new GetSubScreens() { ID = ScreenID });
                string listout = "";
                foreach (var s in screens)
                {
                    listout = listout + htmlTemplate.Replace("$path", "dv_" + s.DirectoryPath.Replace("/", "_")).Replace("$icon", s.Icon).Replace("$title", s.Title).Replace("$id", s.Id.ToString());
                }
                SubScreens = listout;
            }
            catch (Exception ex)
            {

            }
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateContractCommand command)
        {
            try
            {
                IEnumerable<SearchContractModel> SaveResult = new List<SearchContractModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات قرار داد موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchContractQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchContractModel> SaveResult = new List<SearchContractModel>();
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