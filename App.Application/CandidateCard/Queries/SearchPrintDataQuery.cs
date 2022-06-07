using App.Application.CandidateCard.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.CandidateCard.Queries
{
    public class SearchPrintDataQuery : IRequest<List<SearchPrintDataModel>>
    {
        public int ID { get; set; }
        public string Flag { get; set; }
    }
    public class SearchPrintDataQueryHandler : IRequestHandler<SearchPrintDataQuery, List<SearchPrintDataModel>>
    {
        private AppDbContext Context { get; set; }
        public SearchPrintDataQueryHandler(AppDbContext context)
        {
            Context = context;
        }
        public async Task<List<SearchPrintDataModel>> Handle(SearchPrintDataQuery request, CancellationToken cancellationToken)
        {
            var query = Context.Candidates.Include( A => A.Address).Include(I => I.Passport).AsQueryable();
            if (request.ID != 0)
            {
                query = query.Where(e => e.Id == request.ID);
            }
            return await query.Select(e => new SearchPrintDataModel
            {
                Id = e.Id,
                Code = e.Code,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.FatherName,
                FirstNameEnglish = e.FirstNameEnglish,
                LastNameEnglish = e.LastNameEnglish,
                FatherNameEnglish = e.FatherNameEnglish,
                GrandFatherNameEnglish = e.GrandFatherNameEnglish,
                ProvinceName = e.Address.Cprovince.Dari,
                DistrictName = e.Address.Cdistrict.Dari,
                FullAddress = e.Address.CfullAdd,
                PassportNo = ( e.Passport.PassportNo == 0 ? "" : e.Passport.PassportNo.ToString()),
                IssueDate=  e.Passport.IssueDate == null ? " " : PersianDate.GetFormatedString(e.Passport.IssueDate),
                ExpairyDate =e.Passport.IssueDate == null ? " " : PersianDate.GetFormatedString( e.Passport.ExpairyDate),
                IssuseYear = Convert.ToInt32(e.Passport.IssueDate.Value.Year).ToString(),
                ExpiryYear = Convert.ToInt32(e.Passport.ExpairyDate.Value.Year).ToString(),
                Mahram = ( e.Mahram.FirstName == null ? "ندارد" : e.Mahram.FirstName ),
                RelationshipName = ( e.Relationship.Name == null ? "ندارد" : e.Relationship.Name ),
                PhotoPath = e.PhotoPath,
                
            }).ToListAsync();
        }
    }
}
