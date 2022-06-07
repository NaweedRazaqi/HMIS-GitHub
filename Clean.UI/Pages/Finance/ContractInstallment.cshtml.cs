using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ContractInstallmentModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList ());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfCurrency = new List<SelectListItem>();
            var Currency = await Mediator.Send(new GetCurrencyList ());
            Currency.ForEach(e => ListOfCurrency.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfContract = new List<SelectListItem>();
            var Contract = await Mediator.Send(new GetContractList());
            Contract.ForEach(e => ListOfContract.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.ContractDetails}));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateContractInstallmentCommand command)
        {
            try
            {
                IEnumerable<SearchContractInstallmentModel> SaveResult = new List<SearchContractInstallmentModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات قرار تعرفه موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchContractInstallmentQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchContractInstallmentModel> SaveResult = new List<SearchContractInstallmentModel>();
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