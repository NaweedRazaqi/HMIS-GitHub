using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Lookup.Queries;
using App.Application.Qouta.Commands;
using App.Application.Qouta.Models;
using App.Application.Qouta.Queries;
using Clean.Application.System.Queries;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Clean.UI.Pages.Qouta
{
    public class QoutaModel : BasePage
    {
        public string SubScreens { get; set; }

        private string htmlTemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>";
        public async Task OnGetAsync([FromRoute]int id)
        {
            
            ListOfSpecialEntityType = new List<SelectListItem>();
            var specialEntityTypes = await Mediator.Send(new GetSpecialEntityTypeList() { TypeId = 2 });
            foreach (var spe in specialEntityTypes)
                ListOfSpecialEntityType.Add(new SelectListItem(spe.Dari, spe.Id.ToString()));

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
        public async Task<IActionResult> OnPostSave([FromBody] CreateQoutaCommand command)
        {
            try
            {
                IEnumerable<SearchQoutaModel> SaveResult = new List<SearchQoutaModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "شهرت حاجی موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchQoutaQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchQoutaModel> SaveResult = new List<SearchQoutaModel>();

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
                    Description = ex.Message ,// + " \n StackTrace : " + ex.StackTrace,
                    Data = null
                };
            }
            return result;
        }
    }
}