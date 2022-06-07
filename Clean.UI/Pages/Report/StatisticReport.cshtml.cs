using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Domain.Entity.rep;
using Clean.Common.Models;
using App.Application.Report.Models;
using App.Application.Report.Queries;

namespace Clean.UI.Pages.Report
{
    public class StatisticReportModel : BasePage
    {
        public async Task OnGetAsync()
        { 
            ListOfTables = new List<SelectListItem>();
            List<Dbobject> Objects = await Mediator.Send(new SearchDBObjectQuery() { Type = 1 });

            foreach (Dbobject m in Objects)
                ListOfTables.Add(new SelectListItem(m.DisplayName, m.Id.ToString()));
        }
        public async Task<IActionResult> OnPostColumns([FromBody] DynamicListModel Data)
        {
            var result = new JsonResult(null);
            try
            {
                List<object> SearchResult = new List<object>();
                List<SearchDBObjectObjectModel> columns = new List<SearchDBObjectObjectModel>();
                columns = await Mediator.Send(new SearchDBObjectObjectQuery() { ParentID = Convert.ToInt32(Data.ID) });
                foreach (SearchDBObjectObjectModel l in columns)
                    SearchResult.Add(new { id = l.ChildID, text = l.ChildText });
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
        public async Task<IActionResult> OnPostReport([FromBody] GetReportQuery query)
        {
            var result = new JsonResult(null);
            try
            {
                IEnumerable<SearchedReportModel> SearchResult = new List<SearchedReportModel>();
                SearchResult = await Mediator.Send(query);
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