using App.Application.Candidate.Models;
using App.Persistence.Context;
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
    public class SearchHajiDetailsQuery : IRequest<IEnumerable<SearchHajiDetailsModel>>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string Genders { get; set; }
        public string Relegions { get; set; }
        public string Ctype { get; set; }
        public int? Mahramid { get; set; }
        public string Mahramname { get; set; }
        public string Mahramlast { get; set; }
    }
    public class SearchHajiDetailsQueryHandler : IRequestHandler<SearchHajiDetailsQuery, IEnumerable<SearchHajiDetailsModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchHajiDetailsQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchHajiDetailsModel>> Handle(SearchHajiDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = context.HajiMahramdetails.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (!String.IsNullOrEmpty(request.Code))
            {
                query = query.Where(e => e.Code == request.Code);
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
            if (!String.IsNullOrEmpty(request.GrandFatherName))
            {
                query = query.Where(e => e.GrandFatherName == request.GrandFatherName);
            }
           
          
            return await query.Select(p => new SearchHajiDetailsModel
            {
                Id = p.Id,
                Code = p.Code,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FatherName = p.FatherName,
                GrandFatherName = p.GrandFatherName,
                Ctype=p.Ctype,
                Relegions=p.Relegions,
                Mahramname=p.Mahramname,
                Mahramlast= p.Mahramlast,
                Genders=p.Genders,
        }).ToListAsync();

            
        }
    }
}
