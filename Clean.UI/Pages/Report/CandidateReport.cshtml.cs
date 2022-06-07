using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Models;
using App.Application.Lookup.Queries;
using Clean.Application.System.Queries;
using Clean.Common;
using Clean.Common.Enums;
using Clean.Common.Storage;
using Clean.Persistence.Services;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
namespace Clean.UI.Pages.Report
{
    public class CandidateReportModel : BasePage
    {
        public string SubScreens { get; set; }

        private string htmlTemplate = @"
                         <li><a href='#' data='$id' page='$path' class='sidebar-items' action='subscreen'><i class='$icon'></i>$title</a></li>";
        public async Task OnGetAsync([FromRoute]int id)
        {
            ListOfGenders = new List<SelectListItem>();
            var genders = await Mediator.Send(new GetGenderList());
            genders.ForEach(e => ListOfGenders.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfHajjProcessStatus = new List<SelectListItem>();
            var hps = await Mediator.Send(new GetHajjprocessStatus());
            hps.ForEach(e => ListOfHajjProcessStatus.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Dari }));

            ListOfMaritalStatus = new List<SelectListItem>();
            var maritals = await Mediator.Send(new GetMaritalStatusList());
            maritals.ForEach(e => ListOfMaritalStatus.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfRelationShip = new List<SelectListItem>();
            var Relations = await Mediator.Send(new GetRelationList());
            Relations.ForEach(e => ListOfRelationShip.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfReligions = new List<SelectListItem>();
            var Religions = await Mediator.Send(new GetReligionList());
            Religions.ForEach(e => ListOfReligions.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name }));

            ListOfBloodGroups = new List<SelectListItem>();
            var BloodGroup = await Mediator.Send(new GetBloodGroupList());
            BloodGroup.ForEach(e => ListOfBloodGroups.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfCandidateTypes = new List<SelectListItem>();
            var CandidateType = await Mediator.Send(new GetCandidateTypeList());
            CandidateType.ForEach(e => ListOfCandidateTypes.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Dari }));

            ListOfSpecialEntity = new List<SelectListItem>();
            var SpecialEntity = await Mediator.Send(new GetSpecialEntityList());
            SpecialEntity.ForEach(e => ListOfSpecialEntity.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.OrderNo.ToString() }));

            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));


            ListOfDocumentTypes = new List<SelectListItem>();
            List<DocumentTypeModel> documentTypes = new List<DocumentTypeModel>();
            documentTypes = await Mediator.Send(new GetDocumentTypeQuery() { ScreenID = 8, Category = "NID" });
            foreach (DocumentTypeModel documentType in documentTypes)
                ListOfDocumentTypes.Add(new SelectListItem() { Text = documentType.Name, Value = documentType.DocumentTypeId.ToString() });



            //list of language
            ListOfLanguage = new List<SelectListItem>();
            var L = await Mediator.Send(new SearchLanguage());
            L.ForEach(l => ListOfLanguage.Add(new SelectListItem { Value = l.Id.ToString(), Text = l.Local }));


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

        public async Task<IActionResult> OnPostSearch([FromBody] SearchCandidateQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchCandidateModel> SaveResult = new List<SearchCandidateModel>();

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
        // Report to Excells

    }
}