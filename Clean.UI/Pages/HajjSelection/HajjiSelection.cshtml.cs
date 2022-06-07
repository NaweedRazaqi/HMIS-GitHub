using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using Clean.Application.System.Queries;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.UI.Pages.HajjSelection
{
    public class HajjiSelectionModel : BasePage
    {
        public string SubScreens { get; set; }
        private string htmlTemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>";
        public async Task OnGetAsync()
        {
            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));


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
        public async Task<IActionResult> OnPostSearch([FromBody] SelectCandidateQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SelectCandidateModel> SaveResult = new List<SelectCandidateModel>();

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
