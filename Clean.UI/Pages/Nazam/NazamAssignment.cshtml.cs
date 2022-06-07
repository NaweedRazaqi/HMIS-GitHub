using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Commands;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Application.Lookup.Queries;
using Clean.Application.System.Queries;
using Clean.Common;
using Clean.Common.Enums;
using Clean.Common.Storage;
using Clean.UI.Types;
using Clean.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clean.UI.Pages.Nazam
{
    public class NazamAssignmentModel : BasePage
    {
        public async Task OnGetAsync()
        {
            ListOfGenders = new List<SelectListItem>();
            var genders = await Mediator.Send(new GetGenderList());
            genders.ForEach(e => ListOfGenders.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfMaritalStatus = new List<SelectListItem>();
            var maritals = await Mediator.Send(new GetMaritalStatusList());
            maritals.ForEach(e => ListOfMaritalStatus.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));

            ListOfBloodGroups = new List<SelectListItem>();
            var BloodGroup = await Mediator.Send(new GetBloodGroupList());
            BloodGroup.ForEach(e => ListOfBloodGroups.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.Name }));
        }

        public async Task<IActionResult> OnPostSearch([FromBody] SearchNazamAssignmentQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchNazamAssignmentModel> SaveResult = new List<SearchNazamAssignmentModel>();
                query.CandidateTypeId = 1;
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
        public async Task<IActionResult> OnPostSave([FromBody] CreateNazamAssignmentCommand command)
        {
            try
            {
                IEnumerable<SearchNazamAssignmentModel> SaveResult = new List<SearchNazamAssignmentModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "تعین ناظم به حاجی موفقانه ثبت گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
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