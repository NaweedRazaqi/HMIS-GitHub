using App.Application.Candidate.Models;
using App.Persistence.Context;
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

namespace App.Application.Candidate.Queries
{
    public class SearchAddressQuery : IRequest<IEnumerable<SearchAddressModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int CprovincesId { get; set; }
        public int CdistrictsId { get; set; }
        public int PermanentProvincesId { get; set; }
        public int PdistrictsId { get; set; }
    }
    public class SearchAddressQueryHandler : IRequestHandler<SearchAddressQuery, IEnumerable<SearchAddressModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        private AppIdentityDbContext IDContext;

        public SearchAddressQueryHandler(AppDbContext context, ICurrentUser currentUser, AppIdentityDbContext idContext)
        {
            this.context = context;
            User = currentUser;
            IDContext = idContext;
        }
        public async Task<IEnumerable<SearchAddressModel>> Handle(SearchAddressQuery request, CancellationToken cancellationToken)
        {
            var query = context.Addresses.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.CandidateId != 0)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            if (request.CprovincesId != 0)
            {
                query = query.Where(e => e.CprovinceId == request.CprovincesId);
            }
            if (request.CdistrictsId != 0)
            {
                query = query.Where(e => e.CdistrictId == request.CdistrictsId);
            }
            if (request.PermanentProvincesId != 0)
            {
                query = query.Where(e => e.PprovinceId == request.PermanentProvincesId);
            }
            if (request.PdistrictsId != 0)
            {
                query = query.Where(e => e.PdistrictId == request.PdistrictsId);
            }
            return await query.Select(p => new SearchAddressModel
            {
                Id = p.Id,  
                CandidateId = p.CandidateId,  
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                CProvinceId = p.CprovinceId,
                CDistrictId = p.CdistrictId,
                CfullAdd  = p.CfullAdd,
                PProvinceId = p.PprovinceId,
                PDistrictId = p.PdistrictId,
                PfullAdd  = p.PfullAdd,
                Mobile  = p.Mobile,
                Phone  = p.Phone,
                Email = p.Email,
                DistrictNumber=p.DistrictNumber,
                CProvinceName = p.Cprovince.Dari,
                CDistrictName = p.Cdistrict.Dari,
                PDistrictName = p.Pdistrict.Dari,
                PProvinceName = p.Pprovince.Dari,
            }).ToListAsync();
        }
    }
}
