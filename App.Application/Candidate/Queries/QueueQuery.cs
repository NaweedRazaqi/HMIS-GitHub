using App.Application.Candidate.Models;
using App.Persistence.Context;
using Clean.Common.Dates;
using Clean.Persistence.Identity;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Queries
{
    public class QueueQuery : IRequest<IEnumerable<QueueModel>>
    {

        public long Id { get; set; }
        public int CandidateId { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? SelectedOn { get; set; }
        public int? CurrentYearsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int? GenderId { get; set; }
    }
    public class QueueQueryHandler : IRequestHandler<QueueQuery, IEnumerable<QueueModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;
        public QueueQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
        }

        public async Task<IEnumerable<QueueModel>> Handle(QueueQuery request, CancellationToken cancellationToken)
        {
            var query = context.SelectQueues.OrderBy(c=>c.CreatedOn).AsQueryable();
            var enYear = PersianToEnglish(PersianDate.ToPersianDate(DateTime.Now).Substring(0, 4));
          
            var yId = context.Years.Where(e => e.Name.ToString() == enYear).Select(e => e.Id).SingleOrDefault();
          
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }  
            if (request.CurrentYearsId != 0)
            {
                query = query.Where(e => e.CurrentYearsId == yId);
            }

            if (!String.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(e => e.FirstName == request.FirstName);
            }
            if (!String.IsNullOrEmpty(request.LastName))
            {
                query = query.Where(e => e.LastName == request.LastName);
            }
            if (!String.IsNullOrEmpty(request.FatherName))
            {
                query = query.Where(e => e.FatherName == request.FatherName);
            }

            
            return await query.Select(p => new QueueModel 
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FatherName = p.FatherName,
                CreatedOn = p.CreatedOn,
                CurrentYearsId=p.CurrentYearsId,
                Years=  PersianDate.GetFormatedString( p.CreatedOn),
                GenderId = p.GenderId,
                Religion=p.Candidate.Religion.Name,
                Gender =p.Candidate.Gender.Name,
                Code=p.Candidate.Code,
                SelectedOn = p.SelectedOn,
                Status = p.Status,
                CandidateId=p.CandidateId

            }).Take(10).ToListAsync();

        }
        private string[] persion = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private string[] english = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public string PersianToEnglish(string strNum)
        {
            string chash = strNum;
            for (int i = 0; i < 10; i++)
                chash = chash.Replace(persion[i], english[i]);
            return chash;
        }
    }
}
