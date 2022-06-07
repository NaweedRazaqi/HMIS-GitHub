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
    public class DailyExpenseModel : BasePage
    {
        public string SubScreens { get; set; }
        private string htmlTemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>";

        public async Task OnGetAsync()
        {
            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfCurrency = new List<SelectListItem>();
            var Currency = await Mediator.Send(new GetCurrencyList ());
            Currency.ForEach(e => ListOfCurrency.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfMutamid = new List<SelectListItem>();
            var Mutamid = await Mediator.Send(new GetMutamidList());
            Mutamid.ForEach(e => ListOfMutamid.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfExpenseTypes = new List<SelectListItem>();
            var ExpenseTypes = await Mediator.Send(new GetExpenseTypesList());
            ExpenseTypes.ForEach(e => ListOfExpenseTypes.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));


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
        public async Task<IActionResult> OnPostSave([FromBody] CreateDailyExpensesCommand command)
        {
            try
            {
                IEnumerable<SearchDailyExpensesModel> SaveResult = new List<SearchDailyExpensesModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات مصارف روزمره موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchDailyExpensesQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchDailyExpensesModel> SaveResult = new List<SearchDailyExpensesModel>();
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