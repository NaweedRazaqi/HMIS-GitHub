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

namespace Clean.UI.Pages.Eduction
{
    public class EducationModel : BasePage
    {
        public async Task OnGetAsync()
        {
            //edudegree
            ListOfEducationDegree = new List<SelectListItem>();
            var edl = await Mediator.Send(new GetEducationdegreeList());
            edl.ForEach(el => ListOfEducationDegree.Add(new SelectListItem { Value = el.Id.ToString(), Text = el.Name }));
            //for field of study
            ListOfStudyField = new List<SelectListItem>();
            var studyfield = await Mediator.Send(new StudyFieldList());
            studyfield.ForEach(sf => ListOfStudyField.Add(new SelectListItem { Value = sf.Id.ToString(), Text = sf.Text }));
           
            ListOfUniversities = new List<SelectListItem>();
            var university = await Mediator.Send(new GetUniversitiesList());
            university.ForEach(university => ListOfUniversities.Add(new SelectListItem { Value = university.Id.ToString(), Text = university.Name }));

            ListOfLocations = new List<SelectListItem>();
            var locations = await Mediator.Send(new GetCountriesLocation());
            locations.ForEach(location => ListOfLocations.Add(new SelectListItem { Value = location.Id.ToString(), Text = location.Dari }));


        }
        public async Task<IActionResult> OnPostSave([FromBody] CreateEducationCommand command)
        {
            try
            {
                IEnumerable<SearchEducationModel> SaveResult = new List<SearchEducationModel>();

                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = " مشخصات تحصیلی موفقانه ثبت گردید.",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchEducationQuery query)
        {
            var result = new JsonResult(null);
            try
            {

                IEnumerable<SearchEducationModel> SaveResult = new List<SearchEducationModel>();

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