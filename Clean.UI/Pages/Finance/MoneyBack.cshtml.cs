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
    public class MoneyBackModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));

            ListOfRelatives = new List<SelectListItem>();
            var Relative = await Mediator.Send(new GetRelativeList());
            Relative.ForEach(e => ListOfRelatives.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfCurrency = new List<SelectListItem>();
            var Currency = await Mediator.Send(new GetCurrencyList());
            Currency.ForEach(e => ListOfCurrency.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfHajjYear = new List<SelectListItem>();
            var HajjYear = await Mediator.Send(new GetHajjYearList());
            HajjYear.ForEach(e => ListOfHajjYear.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.YearName.ToString() }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateMoneyBackCommand command)
        {
            try
            {
                IEnumerable<SearchMoneyBackModel> SaveResult = new List<SearchMoneyBackModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات باز پرداخت موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchMoneyBackQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchMoneyBackModel> SaveResult = new List<SearchMoneyBackModel>();
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