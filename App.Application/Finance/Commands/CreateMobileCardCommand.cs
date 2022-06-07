using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Finance.Commands
{
    public class CreateMobileCardCommand : IRequest<List<SearchMobileCardModel>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string JobTitle { get; set; }
        public string SpentFor { get; set; }
        public int? MutamidId { get; set; }
        public string AreaToContact { get; set; }
        public int NumberOfHaji { get; set; }
        public int CostPerMinute { get; set; }
        public int DurationInMinutes { get; set; }
        public int CostPerHaji { get; set; }
        public int TotalCost { get; set; }
        public int TotalPayebale { get; set; }
        public string RecievingPlace { get; set; }
        public string Comments { get; set; }
    }
    public class CreateMobileCardCommandHandler : IRequestHandler<CreateMobileCardCommand, List<SearchMobileCardModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateMobileCardCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchMobileCardModel>> Handle(CreateMobileCardCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();

            var MobileCard = request.Id !=0 ? context.MobileCards.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.MobileCards();
            IEnumerable<SearchMobileCardModel> result = new List<SearchMobileCardModel>();

            MobileCard.Name = request.Name;
            MobileCard.FatherName = request.FatherName;
            MobileCard.JobTitle = request.JobTitle;
            MobileCard.Date = request.Date;
            MobileCard.SpentFor = request.SpentFor;
            MobileCard.MutamidId = request.MutamidId;
            MobileCard.AreaToContact = request.AreaToContact;
            MobileCard.NumberOfHaji = request.NumberOfHaji;
            MobileCard.CostPerMinute = request.CostPerMinute;
            MobileCard.DurationInMinutes = request.DurationInMinutes;
            MobileCard.CostPerHaji = request.CostPerHaji;
            MobileCard.TotalCost = request.TotalCost;
            MobileCard.TotalPayebale = request.TotalPayebale;
            MobileCard.RecievingPlace = request.RecievingPlace;
            MobileCard.Comments = request.Comments;
            if (request.Id == 0)
            {
                MobileCard.ModifiedBy = "";
                MobileCard.ModifiedOn = DateTime.Now;
                MobileCard.CreatedBy = CurrentUserId;
                MobileCard.CreatedOn = DateTime.Now;
                context.MobileCards.Add(MobileCard);
            }
            else
            {
                MobileCard.ModifiedBy += "," + CurrentUserId; ;
                MobileCard.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchMobileCardQuery() { Id = MobileCard.Id });
            return result.ToList();
        }
    }
}
