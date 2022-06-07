using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using Clean.UI.Types;
namespace Clean.UI.Pages.Report.PrintReport

{
    public class PrintReportModel : BasePage
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public int? YearId { get; set; }
        public int? CandidateId { get; set; }
        public int? CandidateTypeId { get; set; }

        public List<SearchCandidateModel> Clist { get; set; }


        public async Task OnGet()
        {
            var result = await this.Mediator.Send(new SearchCandidateQuery { });
            Clist = result.ToList();

        }
    }

}
