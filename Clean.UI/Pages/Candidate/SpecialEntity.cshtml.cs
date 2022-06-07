using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using Clean.Common.Models;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Candidate
{
    public class SpecialEntityModel : BasePage
    {
        public async Task OnGetAsync([FromRoute] int id)
        {
            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));


            ListOfSpecialEntityType = new List<SelectListItem>();
            var specialEntityTypes = await Mediator.Send(new GetSpecialEntityTypeList() { TypeId = 1 });
            foreach (var spe in specialEntityTypes)
                ListOfSpecialEntityType.Add(new SelectListItem(spe.Dari, spe.Id.ToString()));


        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateSpecialEntityCommand command)
        {
            try
            {
                IEnumerable<SearchSpecialEntityModel> SaveResult = new List<SearchSpecialEntityModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "سهمیه استثنایی موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }

        public async Task<IActionResult> OnPostSET([FromBody] DynamicListModel Data)
        {
            var result = new JsonResult(null);
            try
            {
                List<object> SearchResult = new List<object>();
                var spet = await Mediator.Send(new GetSpecialEntityTypeList() { ParentId = Data.ID });
                foreach (var s in spet)
                    SearchResult.Add(new { id = s.Id, text = s.Dari });

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SearchResult },
                    Status = UIStatus.Success,
                    Text = "",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                result = new JsonResult(CustomMessages.FabricateException(ex));
            }
            return result;
        }   
        public async Task<IActionResult> OnPostSearch([FromBody] SearchSpecialEntityQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchSpecialEntityModel> SaveResult = new List<SearchSpecialEntityModel>();

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