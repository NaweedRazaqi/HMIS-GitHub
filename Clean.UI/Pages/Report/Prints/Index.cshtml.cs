using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;

namespace Clean.UI.Pages.Report.Prints

{
    public class IndexModel : BasePage
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Mahram { get; set; }
        public string Relations { get; set; }
        //Relative
        public string rFirstName { get; set; }
        public string rLastName { get; set; }
        public string rFatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string RelationshipName { get; set; }
        public string FullAddress { get; set; }
        public string ProvincesName { get; set; }
        public string DistrictName { get; set; }

        //Address
        public string CProvinceName { get; set; }
        public string CDistrictName { get; set; }
        public string PDistrictName { get; set; }
        public string PProvinceName { get; set; }
        public string CandidateName { get; set; }
        //Job
        public string jCandidateName { get; set; }
        public string OrganizationName { get; set; }
        public string JobType { get; set; }
        public string JobTitle { get; set; }

        public async Task OnGet([FromQuery] int recordId)
        {
            var result = await this.Mediator.Send(new SearchCandidateQuery { Id = recordId });
            var cur = result.FirstOrDefault();

            FirstName = cur.FirstName;
            FatherName = cur.FatherName;
            LastName = cur.LastName;
            GrandFatherName = cur.GrandFatherName;
            Code = cur.Code;
            Mahram = cur.Mahram;
            Relations = cur.RMahram;
            // Relative Query

            var relative = await this.Mediator.Send(new SearchRelativeQuery { CandidateId = recordId });
            var r = relative.FirstOrDefault();
            rFirstName = r.FirstName;
            rLastName = r.LastName;
            RelationshipName = r.RelationshipName;
            ProvincesName = r.ProvincesName;
            DistrictName = r.DistrictName;
            FullAddress = r.FullAddress;
            // Address Query
            var add = await this.Mediator.Send(new SearchAddressQuery { CandidateId = recordId });
            var Ad = add.FirstOrDefault();
            CProvinceName = Ad.CProvinceName;
            CDistrictName = Ad.CDistrictName;
            PDistrictName = Ad.PDistrictName;
            PProvinceName = Ad.PProvinceName;
            CandidateName = Ad.CandidateName;

            // jobs
            var job = await this.Mediator.Send(new SearchJobQuery { CandidateId = recordId });
            var jo = job.FirstOrDefault();
            jCandidateName = jo.CandidateName;
            OrganizationName = jo.OrganizationName;
            JobType = jo.JobType;
            //JobTitle = jo.JobTitle;
        }
    }
}
