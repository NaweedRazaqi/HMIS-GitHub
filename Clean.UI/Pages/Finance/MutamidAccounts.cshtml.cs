using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Finance.Commands;
using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Application.Lookup.Queries;
using Clean.Application.Documents.Queries;
using Clean.Application.System.Queries;
using Clean.Common;
using Clean.Common.Enums;
using Clean.Common.Models;
using Clean.Common.Storage;
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

namespace Clean.UI.Pages.Finance
{
    public class MutamidAccountsModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfMutamid = new List<SelectListItem>();
            var Mutamid = await Mediator.Send(new GetMutamidList());
            Mutamid.ForEach(e => ListOfMutamid.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfCurrency = new List<SelectListItem>();
            var Currency = await Mediator.Send(new GetCurrencyList());
            Currency.ForEach(e => ListOfCurrency.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateMutamidAccountsCommand command)
        {
            try
            {
                IEnumerable<SearchMutamidAccountsModel> SaveResult = new List<SearchMutamidAccountsModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات صورت حساب معتمد موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchMutamidAccountsQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchMutamidAccountsModel> SaveResult = new List<SearchMutamidAccountsModel>();
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