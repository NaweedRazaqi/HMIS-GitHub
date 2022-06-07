using App.Application.Emara.Models;
using App.Application.Emara.Queries;
using App.Persistence.Context;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Emara.Commands
{

    public class CreateHajitoEmaraCommand : IRequest<List<HajjiToEmaraSearchModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? EmaraId { get; set; }
        public int MaktabNo { get; set; }
        public int BuildingNo { get; set; }
        public int FloorNo { get; set; }
        public int RoomNo { get; set; }
        public int BedNo { get; set; }
        public int YearId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class CreateHajitoEmaraCommandHandler : IRequestHandler<CreateHajitoEmaraCommand, List<HajjiToEmaraSearchModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateHajitoEmaraCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }

        public async Task<List<HajjiToEmaraSearchModel>> Handle(CreateHajitoEmaraCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Emaracapacity = context.Emaras.Where(e => e.Id == request.EmaraId && e.YearId == request.YearId).Select(s => s.Capacity).SingleOrDefault();

            var HajiCount = context.HajjiAdditionToEmaras.Where(h => h.EmaraId == request.EmaraId && h.YearId == request.YearId).Count();


            if (request.Id == 0)
            {

                if (HajiCount >= Emaracapacity)
                {
                    throw new BusinessRulesException("ظرفیت اعماره انتخاب شده در این سال تکمیل گردیده است لطفا اعماره دیگر را برای حاجی ثبت نمایید.");
                }
            }
            var addhaji = request.Id != 0 ? context.HajjiAdditionToEmaras.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.HajjiAdditionToEmara();
            IEnumerable<HajjiToEmaraSearchModel> result = new List<HajjiToEmaraSearchModel>();


            addhaji.Id = request.Id;
            addhaji.EmaraId = request.EmaraId;
            addhaji.CandidateId = request.CandidateId;
            addhaji.BedNo = request.BedNo;
            addhaji.RoomNo = request.RoomNo;
            addhaji.MaktabNo = request.MaktabNo;
            addhaji.Remarks = request.Remarks;
            addhaji.YearId = request.YearId;
            addhaji.FloorNo = request.FloorNo;
            addhaji.BuildingNo = request.BuildingNo;

            if (request.Id == 0)
            {
                addhaji.ModifiedBy = "";
                addhaji.ModifiedOn = DateTime.Now;
                addhaji.CreatedBy = CurrentUserId;
                addhaji.CreatedOn = DateTime.Now;
                context.HajjiAdditionToEmaras.Add(addhaji);
            }
            else
            {
                addhaji.ModifiedBy += "," + CurrentUserId; ;
                addhaji.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchHajitoEmaraQuery() { Id = addhaji.Id });
            return result.ToList();
        }
    }
}