using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Nazam
{
    public class NazamToMosqueModel : BasePage
    {

        public async Task OnGetAsync([FromRoute] int id)
        {
            ListOfMosque = new List<SelectListItem>();
            var Mosque = await Mediator.Send(new GetMosqueList());
            Mosque.ForEach(e => ListOfMosque.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            //ListOfLocations = new List<SelectListItem>();
            //var locations = await Mediator.Send(new GetCountriesLocation());
            //locations.ForEach(location => ListOfLocations.Add(new SelectListItem { Value = location.Id.ToString(), Text = location.Dari }));

            ListOfProvinces = new List<SelectListItem>();
            var Province = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Province.ForEach(e => ListOfProvinces.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchNazamToMosqueQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchNazamToMosqueModel> SaveResult = new List<SearchNazamToMosqueModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateNazamToMosqueCommand command)
        {
            try
            {
                IEnumerable<SearchNazamToMosqueModel> SaveResult = new List<SearchNazamToMosqueModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "تعین ناظم به مسجد موفقانه ثبت گردید",
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