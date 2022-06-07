using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Models;
using App.Application.Lookup.Queries;
using Clean.Common.Models;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Candidate
{
    public class RelativeModel : BasePage
    {

     
        public async Task OnGetAsync([FromRoute]int id)
        {

            ListOfProvinces = new List<SelectListItem>();
            var Province = await Mediator.Send(new GetLocationList { Flag = "Province" });
            Province.ForEach(e => ListOfProvinces.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfDistricts = new List<SelectListItem>();
            var District = await Mediator.Send(new GetLocationList { Flag = "District" });
            District.ForEach(e => ListOfDistricts.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

            ListOfRelationShip = new List<SelectListItem>();
            var Relations = await Mediator.Send(new GetRelationList());
            Relations.ForEach(e => ListOfRelationShip.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfGenders = new List<SelectListItem>();
            var genders = await Mediator.Send(new GetGenderList());
            genders.ForEach(e => ListOfGenders.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfDocumentTypes = new List<SelectListItem>();
            List<DocumentTypeModel> documentTypes = new List<DocumentTypeModel>();
            documentTypes = await Mediator.Send(new GetDocumentTypeQuery() { ScreenID = 8, Category = "NID" });
            foreach (DocumentTypeModel documentType in documentTypes)
                ListOfDocumentTypes.Add(new SelectListItem() { Text = documentType.Name, Value = documentType.DocumentTypeId.ToString() });
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchRelativeQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchRelativeModel> SaveResult = new List<SearchRelativeModel>();

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


        public async Task<IActionResult> OnPostSave([FromBody] CreateRelativeCommand command)
        {
            try
            {
                IEnumerable<SearchRelativeModel> SaveResult = new List<SearchRelativeModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "شهرت اقارب موفقانه ثبت و راجستر گردید",
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