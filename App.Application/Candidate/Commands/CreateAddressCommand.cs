using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common.Exceptions;
using Clean.Persistence.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Candidate.Commands
{
    public class CreateAddressCommand : IRequest<List<SearchAddressModel>>
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int CprovinceId { get; set; }
        public int CdistrictId { get; set; }
        public string CfullAdd { get; set; }
        public int PProvinceId { get; set; }
        public int PDistrictId { get; set; }
        public string PfullAdd { get; set; }
        public string? Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? DistrictNumber { get; set; }
       

    }
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, List<SearchAddressModel>>
    {

        private readonly AppDbContext context;
        private readonly IMediator mediator;
        private readonly ICurrentUser currentUser;
        public CreateAddressCommandHandler(AppDbContext context, IMediator mediator, ICurrentUser currentUser)
        {
            this.context = context;
            this.mediator = mediator;
            this.currentUser = currentUser;

        }
        public async Task<List<SearchAddressModel>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            int CurrentUserId = await currentUser.GetUserId();
            bool em = IsValidEmailAddress(request.Email);
            if (request.Email != "")
            {
                if (!em)
                {
                    throw new BusinessRulesException("ایمیل آدرس درست نیست");
                }
            }
            bool mo = true;
            if(request.Mobile != "")
            {
                mo = IsLocalPhoneNumber(request.Mobile.ToString());
            }
           

            bool ph = IsPhoneNumber(request.Phone.ToString());
            if (!ph || !mo )
            {
                throw new BusinessRulesException("شماره  درست نیست! شماره با 07 یا 020 شروع.باید 10 عدد باشد");
            }


            var Address = request.Id != 0 ? context.Addresses.Where(e => e.Id == request.Id).Single() : new Domain.Entity.prf.Address();
            IEnumerable<SearchAddressModel> result = new List<SearchAddressModel>();
            Address.Id = request.Id;
            Address.CandidateId = request.CandidateId;  
            Address.CprovinceId = request.CprovinceId;
            Address.CdistrictId = request.CdistrictId;
            Address.CfullAdd = request.CfullAdd;
            Address.PprovinceId = request.PProvinceId;
            Address.PdistrictId = request.PDistrictId;
            Address.PfullAdd = request.PfullAdd;
            Address.Mobile = request.Mobile;
            Address.Phone = request.Phone;
            Address.Email = request.Email;
            Address.DistrictNumber = request.DistrictNumber;
            if (request.Id == 0)
            {
                Address.ModifiedBy = "";
                Address.ModifiedOn = DateTime.Now;
                Address.CreatedBy = CurrentUserId;
                Address.CreatedOn = DateTime.Now;
                context.Addresses.Add(Address);
            }
            else
            {
                Address.ModifiedBy += "," + CurrentUserId; ;
                Address.ModifiedOn = DateTime.Now;
            }
            await context.SaveChangesAsync();
            result = await mediator.Send(new SearchAddressQuery() { Id = Address.Id });
            return result.ToList();


        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            bool MethodResult = false;

            try
            {
                MailAddress m = new MailAddress(emailAddress);

                MethodResult = m.Address == emailAddress;

            }
            catch //(Exception ex)
            {
                //ex.HandleException();

            }

            return MethodResult;

        }

        public static bool IsPhoneNumber(string number)
        {

            return number[0] == '0' && number[1] == '7' || (number[0] == '0' && number[1] == '2' && number[2] == '0') && number.Length == 10 && IsDigit(number);

        }

      
        public static bool IsLocalPhoneNumber(string number)
        {

            
                return number[0] == '0' && number[1] == '2' && number[2] == '0' && number.Length == 9 && IsDigit(number);
        

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
