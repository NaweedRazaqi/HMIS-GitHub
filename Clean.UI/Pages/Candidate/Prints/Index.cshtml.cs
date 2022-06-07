using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Candidate.Models;
using App.Application.Candidate.Queries;
using App.Persistence.Context;
using Clean.Common;
using Clean.Common.Storage;
using Clean.Persistence.Services;
using Clean.UI.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Clean.UI.Pages.Candidate.Prints

{
    public class IndexModel : BasePage
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Mahram { get; set; }
        public string NIDText { get; set; }
        public string age { get; set; }
        public string ProfilePhoto { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Relations { get; set; }
        public string Religion { get; set; }
        //for address
        public string CProvinceName { get; set; }
        public string CDistrictName { get; set; }
        public string Vilage { get; set; }
        public string JobTitle { get; set; }
        //Passport Info
        public string PCandidateName { get; set; }
        public string IssueDateShamsi { get; set; }
        public string ExpairyDateShamsi { get; set; }
        public string PTypeText { get; set; }
        //Relative
        public string rFirstName { get; set; }
        public string rLastName { get; set; }
        public string rFatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string Code { get; set; }
        public string RelationshipName { get; set; }
        public string FullAddress { get; set; }
        public string ProvincesName { get; set; }
        public string DistrictName { get; set; }

        //Address
        //public string CProvinceName { get; set; }
        //public string CDistrictName { get; set; }
        public string PDistrictName { get; set; }
        public string PProvinceName { get; set; }
        public string CandidateName { get; set; }
        //Job
        public string jCandidateName { get; set; }
        public string OrganizationName { get; set; }
        public string JobType { get; set; }
        //public string JobTitle { get; set; }

        // Installments
        public string ICandidateName { get; set; }
        public string InstallmentTypeName { get; set; }
        public string DateShamsi { get; set; }
        public int Amount { get; set; }
        public int RecipetNo { get; set; }
        public string BankName { get; set; }
        public int? InstallmentNo { get; set; }
        public string CurrencyName { get; set; }
        public int psNummber { get; set; }

        private readonly AppDbContext Context;
        private readonly IConfiguration Config;
        public IndexModel(IConfiguration configuration, ICurrentUser currentUser,AppDbContext context)
        {
            Config = configuration;
            this.Context = context;
        }
        public async Task OnGet([FromQuery] int recordId)
        {
            var result = await this.Mediator.Send(new SearchCandidateQuery { Id = recordId });
            var cur = result.FirstOrDefault();
            FirstName = cur.FirstName;
            FatherName = cur.FatherName;
            GrandFatherName = cur.GrandFatherName;
            LastName = cur.LastName;
            NIDText = cur.NIDText;
            age = cur.age;
            Religion = cur.ReligionName;
            PhoneNumber = cur.PhoneNumber;
            PhoneNumber2 = cur.PhoneNumber2;
            ProfilePhoto = await GetFile("ProfilePhotos", cur.PhotoPath);
            //for add
            CProvinceName = cur.ProvinceName;
            CDistrictName = cur.DestrictName;
            Vilage = cur.Vilage;
            JobTitle = cur.JobTitle;
            //Passport Info

            var passport = await this.Mediator.Send(new SearchIdentificationQuery { CandidateId = recordId });
            var ps = passport.FirstOrDefault();

            if (!passport.Any())
            {
                PCandidateName = "معلومات موجود نیست";
                IssueDateShamsi = "معلومات موجود نیست";
                ExpairyDateShamsi = "معلومات موجود نیست";
                PTypeText = "معلومات موجود نیست";
                psNummber = 0;
            }
            if (passport.Any())
            {
                PCandidateName = ps.CandidateName;
                IssueDateShamsi = ps.IssueDateShamsi;
                ExpairyDateShamsi = ps.ExpairyDateShamsi;
                PTypeText = ps.PTypeText;
                psNummber = ps.PassportNo;
            }
            // Relative Query

            var relative = await this.Mediator.Send(new SearchRelativeQuery { CandidateId = recordId });
            var r = relative.FirstOrDefault();
            if (!passport.Any())
            {
                rFirstName = "معلومات موجود نیست";
                rLastName = "معلومات موجود نیست";
                RelationshipName = "معلومات موجود نیست";
                ProvincesName = "معلومات موجود نیست";
                DistrictName = "معلومات موجود نیست";
                FullAddress = "معلومات موجود نیست";
                if (passport.Any())
                {
                    rFirstName = r.FirstName;
                    rLastName = r.LastName;
                    RelationshipName = r.RelationshipName;
                    ProvincesName = r.ProvincesName;
                    DistrictName = r.DistrictName;
                    FullAddress = r.FullAddress;
                }

                // Address Query
                var add = await this.Mediator.Send(new SearchAddressQuery { CandidateId = recordId });
                var Ad = add.FirstOrDefault();
                if (!add.Any())
                {
                    CProvinceName = "معلومات موجود نیست";
                    CDistrictName = "معلومات موجود نیست";
                    PDistrictName = "معلومات موجود نیست";
                    PProvinceName = "معلومات موجود نیست";
                    CandidateName = "معلومات موجود نیست";

                }
                if (add.Any())
                {
                    CProvinceName = Ad.CProvinceName;
                    CDistrictName = Ad.CDistrictName;
                    PDistrictName = Ad.PDistrictName;
                    PProvinceName = Ad.PProvinceName;
                    CandidateName = Ad.CandidateName;

                }

                // jobs
                var job = await this.Mediator.Send(new SearchJobQuery { CandidateId = recordId });
                var jo = job.FirstOrDefault();
                if (!job.Any())
                {
                    jCandidateName = "معلومات موجود نیست";
                    OrganizationName = "معلومات موجود نیست";
                    JobType = "معلومات موجود نیست";
                    JobTitle = "معلومات موجود نیست";
                }
                if (job.Any())
                {
                    jCandidateName = jo.CandidateName;
                    OrganizationName = jo.OrganizationName;
                    JobType = jo.JobType;
                   // jo = jo.JobTitle;
                }


                //Installents
                var installment = await this.Mediator.Send(new SearchInstallmentQuery { CandidateId = recordId });
                var inst = installment.FirstOrDefault();
                if (!installment.Any())
                {
                    ICandidateName = "معلومات موجود نیست";
                    InstallmentTypeName = "معلومات موجود نیست";
                    Amount = 0;
                    RecipetNo = 0;
                    BankName = "معلومات موجود نیست";
                    InstallmentNo = 0;
                    CurrencyName = "معلومات موجود نیست";
                    DateShamsi = "معلومات موجود نیست";
                }
                if (installment.Any())
                {
                    ICandidateName = inst.CandidateName;
                    InstallmentTypeName = inst.InstallmentTypeName;
                    Amount = inst.Amount;
                    RecipetNo = inst.RecipetNo;
                    BankName = inst.BankName;
                    InstallmentNo = inst.InstallmentNo;
                    CurrencyName = inst.CurrencyName;
                    DateShamsi = inst.DateShamsi;
                }


            }

        }

        public async Task<string> GetFile(String Dir, String FileName)
        {
            FileStorage _storage = new FileStorage();
            var filepath = Config[Dir] + FileName;
            var dirpath = AppConfig.ImagesPath;
            var fullpath = dirpath + filepath;
            System.IO.Stream filecontent = await _storage.GetAsync(fullpath);

            byte[] filebytes = new byte[filecontent.Length];
            filecontent.Read(filebytes, 0, Convert.ToInt32(filecontent.Length));
            String Result = "data:" + _storage.GetContentType(filepath) + ";base64," + Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
            return Result;
        }


    }
}