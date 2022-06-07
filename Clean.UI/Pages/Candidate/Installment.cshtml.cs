using System;
using System.Collections.Generic;
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
    public class InstallmentModel : BasePage
    {

        public async Task OnGetAsync([FromRoute]int id)
        {
           
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfBanks = new List<SelectListItem>();
            var Bank = await Mediator.Send(new GetBankList());
            Bank.ForEach(e => ListOfBanks.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));
            
            //list of order
            ListOfOrders = new List<SelectListItem>();
            var order = await Mediator.Send(new OrderQueryList());
            order.ForEach(e => ListOfOrders.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));
           //list of tdiscount
            ListOfTicketDiscount = new List<SelectListItem>();
            var tdiscount = await Mediator.Send(new TicketDiscountQueryList());
            tdiscount.ForEach(e => ListOfTicketDiscount.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));
            // list of ticketorder
            ListOfTicketorder = new List<SelectListItem>();
            var torder = await Mediator.Send(new TicketOrderQueryList());
            torder.ForEach(e => ListOfTicketorder.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));

            ListOfCurrency = new List<SelectListItem>();
            var Currency = await Mediator.Send(new GetCurrencyList());
            Currency.ForEach(e => ListOfCurrency.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfInstallmentType = new List<SelectListItem>();
            var InstallmentType = await Mediator.Send(new GetInstallmentTypeList());
            InstallmentType.ForEach(e => ListOfInstallmentType.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

           
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchInstallmentQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchInstallmentModel> SaveResult = new List<SearchInstallmentModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateInstallmentCommand command)
        {
            try
            {
                IEnumerable<SearchInstallmentModel> SaveResult = new List<SearchInstallmentModel>();
                SaveResult = await Mediator.Send(command);
              
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "تعرفه بانک موفقانه ثبت و راجستر گردید",
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