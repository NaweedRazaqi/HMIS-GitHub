using App.Application.Finance.Models;
using App.Application.Finance.Queries;
using App.Persistence.Context;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Finance.Commands
{
    public class CreateWageCommand : IRequest<List<SearchWageModel>>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int EmployeeContractTypeId { get; set; }
        public string JobTitle { get; set; }
        public string WorkingCommitee { get; set; }
        public int? PerDayWage { get; set; }
        public int NoOfDays { get; set; }
        public int TotalWage { get; set; }
        public int? AbsentyDeduction { get; set; }
        public int? TaxDeduction { get; set; }
        public int? TotalPayment { get; set; }
        public string Comments { get; set; }
    }
    public class CreateWageCommandHandler : IRequestHandler<CreateWageCommand, List<SearchWageModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateWageCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchWageModel>> Handle(CreateWageCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            var Wage = request.Id != 0 ? context.Wages.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Wages();
            IEnumerable<SearchWageModel> result = new List<SearchWageModel>();
            Wage.Date = request.Date;
            Wage.Name = request.Name;
            Wage.FatherName = request.FatherName;
            Wage.EmployeeContractTypeId = request.EmployeeContractTypeId;
            Wage.JobTitle = request.JobTitle;
            Wage.WorkingCommitee = request.WorkingCommitee;
            Wage.PerDayWage = request.PerDayWage;
            Wage.NoOfDays = request.NoOfDays;
            Wage.TotalWage = request.TotalWage;
            Wage.AbsentyDeduction = request.AbsentyDeduction;
            Wage.TaxDeduction = request.TaxDeduction;
            Wage.TotalPayment = request.TotalPayment;
            Wage.Comments = request.Comments;
            if (request.Id == 0)
            {
                Wage.ModifiedBy = "";
                Wage.ModifiedOn = DateTime.Now;
                Wage.CreatedBy = CurrentUserId;
                Wage.CreatedOn = DateTime.Now;
                context.Wages.Add(Wage);
            }
            else
            {
                Wage.ModifiedBy += "," + CurrentUserId; ;
                Wage.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchWageQuery() { Id = Wage.Id });
            return result.ToList();
        }
    }
}
