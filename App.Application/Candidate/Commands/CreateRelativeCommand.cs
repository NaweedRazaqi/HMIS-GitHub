using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
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

namespace App.Application.Candidate.Commands
{
    public class CreateRelativeCommand : IRequest<List<SearchRelativeModel>>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        //public int Nidno { get; set; }
        //public string Profession { get; set; }
        public int ProvincesId { get; set; }
        public int DistrictId { get; set; }
        //public string FullAddress { get; set; }
        public int RelationshipId { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public string Remarks { get; set; }
        public int DocumentTypeId { get; set; }
        public string NID { get; set; }
        public string FullAddress { get; set; }

    }
    public class CreateRelativeCommandHandler : IRequestHandler<CreateRelativeCommand, List<SearchRelativeModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateRelativeCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchRelativeModel>> Handle(CreateRelativeCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            bool mo = IsPhoneNumber(request.Mobile.ToString());
            bool ph = IsPhoneNumber(request.Phone.ToString());
            if (!ph || !mo)
            {
                throw new BusinessRulesException("شماره  درست نیست! شماره با 07  یا  020 شروع.باید 10 عدد باشد");
            }

            var RL = request.Id != 0 ? context.Relatives.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Relative();
            IEnumerable<SearchRelativeModel> result = new List<SearchRelativeModel>();

            RL.CandidateId = request.CandidateId;
            RL.ProvincesId = request.ProvincesId;
            RL.DistrictId = request.DistrictId;
            RL.FirstName = request.FirstName;
            RL.LastName = request.LastName;
            RL.FatherName = request.FatherName;
            RL.GrandFatherName = request.GrandFatherName;
            RL.GenderId = request.GenderId;
            RL.RelationshipId = request.RelationshipId;
            RL.Mobile = request.Mobile;
            RL.Phone = request.Phone;
            RL.Remarks = request.Remarks;
            RL.DocumentTypeId = request.DocumentTypeId;
            RL.NationalId = request.NID;
            RL.FullAddress = request.FullAddress;
            if (request.Id == 0)
            {
                RL.ModifiedBy = "";
                RL.ModifiedOn = DateTime.Now;
                RL.CreatedBy = CurrentUserId;
                RL.CreatedOn = DateTime.Now;
                context.Relatives.Add(RL);
            }
            else
            {
                RL.ModifiedBy += "," + CurrentUserId; ;
                RL.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchRelativeQuery() { Id = RL.Id });
            return result.ToList();

        }

        public static bool IsPhoneNumber(string number)
        {

            return number[0] == '0' && number[1] == '7' || (number[0] == '0' && number[1] == '2' && number[2]=='0') && number.Length == 10 && IsDigit(number);


        }
        static bool IsDigit(string Input)
        {
            foreach (char c in Input)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
