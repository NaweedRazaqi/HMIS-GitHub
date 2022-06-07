using App.Application.Emara.Models;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Emara.Queries
{

    public class SearchHajitoEmaraQuery : IRequest<IEnumerable<HajjiToEmaraSearchModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? EmaraId { get; set; }
        //public int? BuildingNo { get; set; }
        //public int? FloorNo { get; set; }
        //public int? RoomNo { get; set; }
    }


    public class SearchHajitoEmaraQueryHandler : IRequestHandler<SearchHajitoEmaraQuery, IEnumerable<HajjiToEmaraSearchModel>>
    {
        private readonly AppDbContext context;
        private ICurrentUser User;

        

        public SearchHajitoEmaraQueryHandler(AppDbContext context, ICurrentUser currentUser)
        {
            this.context = context;
            User = currentUser;
        }

        public async Task<IEnumerable<HajjiToEmaraSearchModel>> Handle(SearchHajitoEmaraQuery request, CancellationToken cancellationToken)
        {

            

            var query = context.HajjiAdditionToEmaras.AsQueryable();
            if (request.Id != 0)
            {
                query = query.Where(e => e.Id == request.Id);
            }
            if (request.EmaraId != null)
            {
                query = query.Where(e => e.EmaraId == request.EmaraId);
            } 
            if (request.CandidateId != 0)
            {
                query = query.Where(e => e.CandidateId == request.CandidateId);
            }
            
            
            return await query.Select(p => new HajjiToEmaraSearchModel
            {
                Id = p.Id,
                CandidateId = p.CandidateId,
                CandidateName = p.Candidate.FirstName + " " + p.Candidate.LastName + " ولد " + p.Candidate.FatherName,
                EmaraId = p.EmaraId,
                EmaraDetail = p.Emara.Name + ' ' + p.Emara.EmaraTypeNavigation.Name + " زون" + ' '  + p.Emara.EmaraZoneNavigation.Name + " اعماره نمبر " 
                + ' ' + p.MaktabNo,
                BedNo = p.BedNo,
                FloorNo = p.FloorNo,
                BuildingNo = p.BuildingNo,
                RoomNo = p.RoomNo,
                YearId = p.YearId,
                YearName = p.Year.Name,
                MaktabNo = p.MaktabNo,
                Remarks = p.Remarks
            }).ToListAsync();
        }
    }
}