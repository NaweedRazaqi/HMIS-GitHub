using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using App.Application.Mosque.Commands;
using App.Application.Mosque.Models;
using App.Application.Mosque.Queries;
using Clean.Common.Models;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Mosque
{
    public class MosqueModel : BasePage
    {

        public async Task OnGetAsync()
        {
            ListOfProvinces = new List<SelectListItem>();
            var Province = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Province.ForEach(e => ListOfProvinces.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfDistricts = new List<SelectListItem>();
            var District = await Mediator.Send(new GetLocationList { Flag = "District" });
            District.ForEach(e => ListOfDistricts.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchMosqueQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchMosqueModel> SaveResult = new List<SearchMosqueModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateMosqueCommand command)
        {
            try
            {
                IEnumerable<SearchMosqueModel> SaveResult = new List<SearchMosqueModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "مشخصات مسجد موفقانه ثبت گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostProvince([FromBody] DynamicListModel Data)
        {
            var result = new JsonResult(null);
            try
            {
                List<object> SearchResult = new List<object>();
                var location = await Mediator.Send(new GetLocationList() { ParentID = Data.ID });
                foreach (var l in location)
                    SearchResult.Add(new { id = l.Id, text = l.Dari });

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
    }
}