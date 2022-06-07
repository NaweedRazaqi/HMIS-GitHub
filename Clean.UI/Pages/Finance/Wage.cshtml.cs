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
    public class WageModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfEmployeeContractType = new List<SelectListItem>();
            var EmployeeContractType = await Mediator.Send(new GetEmployeeContractTypeList());
            EmployeeContractType.ForEach(e => ListOfEmployeeContractType.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));
        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateWageCommand command)
        {
            try
            {
                IEnumerable<SearchWageModel> SaveResult = new List<SearchWageModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات حق الزحمه موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchWageQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchWageModel> SaveResult = new List<SearchWageModel>();
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