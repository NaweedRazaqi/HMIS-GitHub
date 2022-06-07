using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Models;
using App.Application.Lookup.Queries;
using Clean.Common;
using Clean.Common.Enums;
using Clean.Common.Storage;
using Clean.UI.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Clean.UI.Pages.Candidate
{
    public class CandidateUpdateStatus : BasePage
    {
        public async Task OnGetAsync([FromRoute]int id)
        {
            ListOfPersianYears = new List<SelectListItem>();
            var Year = await Mediator.Send(new GetYearList());
            Year.ForEach(e => ListOfPersianYears.Add(new SelectListItem { Value = e.Id.ToString(), Text = e.Name.ToString() }));
           
            ListOfHajStatus = new List<SelectListItem>();
            var Hstatus = await Mediator.Send(new GetHajStatusList());
            Hstatus.ForEach(e => ListOfHajStatus.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));
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
            var CandidateType = await Mediator.Send(new GetCandidateTypeList { Flag = "Haji" });
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
        }
        public async Task<IActionResult> OnPostSave([FromBody] UpdateStatusCandidateCommand command)
        {
            try
            {
                IEnumerable<SearchCandidateModel> SaveResult = new List<SearchCandidateModel>();
                SaveResult = await Mediator.Send(command);
                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "تغییرات موفقانه ثبت گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchCandidateQueryUS query)
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

        public async Task<IActionResult> OnPostUpload([FromForm] IFormFile img, [FromForm] string UploadType)
        {
            FileStorage _storage = new FileStorage();
            var extension = System.IO.Path.GetExtension(img.FileName);
            // check for a valid mediatype
            if (!img.ContentType.StartsWith("image/"))
            {
                return new JsonResult(new UIResult()
                {
                    Data = null,
                    Status = 0,
                    Text = "فارمت عکس درست نیست",
                    // Can be changed from app settings
                    Description = ""
                });
            }
            else
            {
                string basePath = "";
                if (UploadType == UploadTypes.Photo)
                {
                    basePath = AppConfig.ImagesPath;
                }
                else if (UploadType == UploadTypes.Signature)
                {
                    basePath = AppConfig.SignaturesPath;
                }
                var additional = DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                string filename = await _storage.CreateAsync(img.OpenReadStream(), extension, basePath + additional);
                var result = new
                {
                    status = "success",
                    url = additional + filename
                };
                return new JsonResult(result);
            }
        }

        public async Task<IActionResult> OnPostCrop([FromBody] CropRequest cropmodel)
        {
            FileStorage _storage = new FileStorage();
            var basePath = "";
            if (cropmodel.uploadType == UploadTypes.Photo)
            {
                basePath = AppConfig.ImagesPath;
            }
            else if (cropmodel.uploadType == UploadTypes.Signature)
            {
                basePath = AppConfig.SignaturesPath;
            }
            var additional = DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            var crs = await _storage.Crop(cropmodel, basePath, additional);
            object result;
            if (crs.Success)
            {
                result = new
                {
                    status = "success",
                    url = additional + crs.ToPath
                };
            }
            else
            {
                result = new
                {
                    status = "fail",
                    url = "",
                    message = crs.ErrorMsg
                };
            }
            return new JsonResult(result);
        }
        public async Task<IActionResult> OnGetDownload([FromQuery] string file, [FromQuery] string uploadType)
        {
            FileStorage _storage = new FileStorage();
            var basePath = "";
            if (uploadType == UploadTypes.Photo)
            {
                basePath = AppConfig.ImagesPath;
            }
            else if (uploadType == UploadTypes.Signature)
            {
                basePath = AppConfig.SignaturesPath;
            }
            var filepath = basePath + file;
            System.IO.Stream filecontent = await _storage.GetAsync(filepath);
            var filetype = _storage.GetContentType(filepath);
            return File(filecontent, filetype, file);
        }
    }
}