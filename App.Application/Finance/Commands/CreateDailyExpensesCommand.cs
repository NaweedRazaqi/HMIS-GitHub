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
    public class CreateDailyExpensesCommand : IRequest<List<SearchDailyExpensesModel>>
    {
        public int Id { get; set; }
        public int? YearId { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseTypeId { get; set; }
        public int M7number { get; set; }
        public DateTime M7date { get; set; }
        public int CurrencyId { get; set; }
        public int ConvertedCurrecyId { get; set; }
        public int ExchangeRate { get; set; }
        public string SpentFrom { get; set; }
        public int MutamidId { get; set; }
        public int NumberOfItems { get; set; }
        public string TotalHawalaAmount { get; set; }
        public int ExchangedAmount { get; set; }
        public string TaxPercentage { get; set; }
        public int Tax { get; set; }
        public string PrivateSector { get; set; }
        public string PrivateSectorPercentage { get; set; }
        public string Penalty { get; set; }
        public int NetAmount { get; set; }
        public int NumberOfPages { get; set; }
        public string MaktoobNo { get; set; }
        public DateTime MaktoobDate { get; set; }
        public int HukamNo { get; set; }
        public DateTime HumkamDate { get; set; }
        public string Comments { get; set; }

    }
    public class CreateDailyExpensesCommandHandler : IRequestHandler<CreateDailyExpensesCommand, List<SearchDailyExpensesModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateDailyExpensesCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchDailyExpensesModel>> Handle(CreateDailyExpensesCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var DailyExpenses = request.Id != 0 ? context.DailyExpenses.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.DailyExpense();
            IEnumerable<SearchDailyExpensesModel> result = new List<SearchDailyExpensesModel>();
            DailyExpenses.Id = request.Id;
            DailyExpenses.YearId = request.YearId;
            DailyExpenses.Date = request.Date;
            DailyExpenses.ExpenseTypeId = request.ExpenseTypeId;
            DailyExpenses.M7number = request.M7number;
            DailyExpenses.M7date = request.M7date;
            DailyExpenses.CurrencyId = request.CurrencyId;
            DailyExpenses.ConvertedCurrecyId = request.ConvertedCurrecyId;
            DailyExpenses.ExchangeRate = request.ExchangeRate;
            DailyExpenses.SpentFrom = request.SpentFrom;
            DailyExpenses.MutamidId = request.MutamidId;
            DailyExpenses.NumberOfItems = request.NumberOfItems;
            DailyExpenses.TotalHawalaAmount = request.TotalHawalaAmount;
            DailyExpenses.ExchangedAmount = request.ExchangedAmount;
            DailyExpenses.TaxPercentage = request.TaxPercentage;
            DailyExpenses.Tax = request.Tax;
            DailyExpenses.PrivateSector = request.PrivateSector;
            DailyExpenses.PrivateSectorPercentage = request.PrivateSectorPercentage;
            DailyExpenses.Penalty = request.Penalty;
            DailyExpenses.NetAmount = request.NetAmount;
            DailyExpenses.NumberOfPages = request.NumberOfPages;
            DailyExpenses.MaktoobNo = request.MaktoobNo;
            DailyExpenses.MaktoobDate = request.MaktoobDate;
            DailyExpenses.HukamNo = request.HukamNo;
            DailyExpenses.HumkamDate = request.HumkamDate;
            DailyExpenses.Comments = request.Comments;
            if (request.Id == 0)
            {
                DailyExpenses.ModifiedBy = "";
                DailyExpenses.ModifiedOn = DateTime.Now;
                DailyExpenses.CreatedBy = CurrentUserId;
                DailyExpenses.CreatedOn = DateTime.Now;
                context.DailyExpenses.Add(DailyExpenses);
            }
            else
            {
                DailyExpenses.ModifiedBy += "," + CurrentUserId; ;
                DailyExpenses.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchDailyExpensesQuery() { Id = DailyExpenses.Id });
            return result.ToList();
        }
    }
}
