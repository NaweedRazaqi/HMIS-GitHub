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
    public class JobModel : BasePage
    {

        public async Task OnGetAsync([FromRoute]int id)
        {
            ListOfCandidate = new List<SelectListItem>();
            var Candidate = await Mediator.Send(new GetCandidateList());
            Candidate.ForEach(e => ListOfCandidate.Add(new SelectListItem { Value = e.ID.ToString(), Text = e.FullName }));

           
            ListOfJobTitle = new List<SelectListItem>();
            var locations = await Mediator.Send(new GetJobTitleList() { TypeID = 1 });
            foreach (var location in locations)
                ListOfJobTitle.Add(new SelectListItem(location.Dari, location.Id.ToString()));

        }
        public async Task<IActionResult> OnPostSearch([FromBody] SearchJobQuery query)
        {
            var result = new JsonResult(null);
            try
            {
              
                IEnumerable<SearchJobModel> SaveResult = new List<SearchJobModel>();

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



        public async Task<IActionResult> OnPostSave([FromBody] CreateJobCommand command)
        {
            try
            {
                IEnumerable<SearchJobModel> SaveResult = new List<SearchJobModel>();
                SaveResult = await Mediator.Send(command);

                return new JsonResult(new UIResult()
                {
                    Data = new { list = SaveResult },
                    Status = UIStatus.Success,
                    Text = "وظیفه موفقانه ثبت و راجستر گردید",
                    Description = string.Empty
                });

            }
            catch (Exception ex)
            {
                return new JsonResult(CustomMessages.FabricateException(ex));
            }
        }


        public async Task<IActionResult> OnPostJob([FromBody] DynamicListModel Data)
        {
            var result = new JsonResult(null);
            try
            {
                List<object> SearchResult = new List<object>();
                var Jtitle = await Mediator.Send(new GetJobTitleList() { ParentID = Data.ID });
                foreach (var l in Jtitle)
                    SearchResult.Add(new { Id = l.OrganizationId, text = l.Dari });

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