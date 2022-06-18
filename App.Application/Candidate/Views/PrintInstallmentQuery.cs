using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Common.Service;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Views
{
    public class PrintInstallmentQuery : IRequest<IEnumerable<PrintInstallmentModel>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string fatherName { get; set; }
    }
    public class PrintInstallmentQueryHandler : IRequestHandler<PrintInstallmentQuery, IEnumerable<PrintInstallmentModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public PrintInstallmentQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<PrintInstallmentModel>> Handle(PrintInstallmentQuery request, CancellationToken cancellationToken)
        {


            List<PrintInstallmentModel> result = new List<PrintInstallmentModel>();
            var query = (from i in context.Installments
                         join c in context.Candidates on i.CandidateId equals c.Id
                         join a in context.Addresses on c.Id equals a.CandidateId
                         join l in context.Locations on a.PprovinceId equals l.Id
                         select new
                         {
                             i.Id,
                             i.CandidateId,
                             c.FirstName,
                             c.FatherName,
                             c.GrandFatherName,
                             a.PprovinceId,
                             a.Cprovince,
                             a.CdistrictId,
                             a.Cdistrict,
                             a.CfullAdd,
                             c.NationalId,
                             c.ReligionId,
                             c.Religion.Name,
                             c.Code
                         }
                ).Where(s => s.Id == request.Id).ToList();


            //if (request.FirstName != null)
            //{
            //    query = query.Where(e => e.FirstName == request.FirstName);
            //}
            //if (request.fatherName != null)
            //{
            //    query = query.Where(e => e.FatherName == request.fatherName);
            //}

            foreach (var item in query)
            {
                PrintInstallmentModel Installment = new PrintInstallmentModel();

                Installment.FirstName = item.FirstName;
                Installment.FatherName = item.FatherName;
                Installment.GrandFatherName = item.GrandFatherName;
                Installment.NationalId = item.NationalId;
                Installment.NIDText = NationalIDReader.ConvertJSONToString(item.NationalId, "").ToString() ?? "درج نگردیده";
                Installment.Religion = context.Religions.Where(i => i.Id == item.ReligionId).Select(s => s.Name).SingleOrDefault();
                Installment.Province = context.Locations.Where(a => a.Id == item.PprovinceId).Select(s => s.PathDari).SingleOrDefault().ToString();
                Installment.Destricts = context.Locations.Where(a => a.Id == item.CdistrictId).Select(s => s.PathDari).SingleOrDefault().ToString();
                Installment.Code = item.Code;
                Installment.Vilege = item.CfullAdd;
                result.Add(Installment);

            }

            return result;
        }
    }
}
