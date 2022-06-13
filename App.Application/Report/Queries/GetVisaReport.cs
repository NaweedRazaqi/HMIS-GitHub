using App.Application.Report.Models;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace App.Application.Report.Queries
{

    public class GetVisaReport : IRequest<IEnumerable<SearchVisaInfoReportModel>>
    {
        public int? ProvinceId { get; set; }

    }

    public class GetVisaReportHandler : IRequestHandler<GetVisaReport, IEnumerable<SearchVisaInfoReportModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        public GetVisaReportHandler(AppDbContext context, ICurrentUser currentUser)
        {
            this.context = context;
            User = currentUser;
        }

        public async Task<IEnumerable<SearchVisaInfoReportModel>> Handle(GetVisaReport request, CancellationToken cancellationToken)
        {

            List<SearchVisaInfoReportModel> result = new List<SearchVisaInfoReportModel>();
            var  query = (
                from v in context.VisaInfos
                join c in context.Candidates on v.CandidateId equals c.Id
                join a in context.Addresses on c.Id equals a.CandidateId
                join l in context.Locations on a.PprovinceId equals l.Id
                select new
                {
                    c.FirstName,
                    c.LastName,
                    a.PprovinceId,
                    v.VisaNo,
                    v.VisaTypeId,
                    l.PathDari,
                    c.FatherName


                }).Where(s => s.PprovinceId == request.ProvinceId).ToList();

            foreach(var item in query)
            {

                SearchVisaInfoReportModel v = new SearchVisaInfoReportModel();
                v.CandidateName = item.FirstName +" "+ "ولد" +" "+ item.FatherName;
                v.ProvinceId = (int)item.PprovinceId;
                v.ProvinceName = item.PathDari;
                result.Add(v);
            }
            return result;
        }
       
    }
}