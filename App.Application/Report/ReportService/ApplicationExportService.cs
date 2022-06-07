using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using App.Persistence.Context;
using System;
using Clean.Common.Dates;
using App.Application.Report.Models;

namespace App.Application.Report.ReportService
{
    public class ApplicationExportService 
    {
        private AppDbContext Context { get; set; }
        private IHostingEnvironment HostingEnv;
        private IConfiguration Configuration { get; set; }
        public int CandidateId { get; set; }

        public ApplicationExportService(AppDbContext _context, IHostingEnvironment _hostingenv, IConfiguration _configuration)
        {
            Context = _context;
            HostingEnv = _hostingenv;
            Configuration = _configuration;
        } 
        public async Task<byte[]> ExportApplicationForm(int requestId)
        {
            var searchresult = await (from p in Context.Candidates
                                      join b in Context.Addresses on p.Id equals b.CandidateId
                                      join a in Context.Relatives on p.Id equals a.CandidateId
                                      //join j in Context.Job on p.Id equals j.ProfileId
                                      join pa in Context.CancelCandidates on p.Id equals pa.CandidateId
                                      //join pt in Context.PersonTitles on p.TitleId equals pt.Id
                                      //join c in Context.Country on p.BirthCountryId equals c.Id
                                      //join pro in Context.Province on p.BirthProvinceId equals pro.Id
                                      //join dis in Context.District on a.DistrictId equals dis.Id
                                      where (p.Id == requestId )
                                      select new ApplicantFormExportRequest {
                                          FirstName= p.FirstName,
                                          LastName= p.LastName,
                                          CDistrictName= b.Cdistrict.Dari
                                          //FamilyNameEn=b.FamilyNameEn,
                                          //Name= b.Name, 
                                          //NameEn= b.NameEn, 
                                          //FatherName= b.FatherName, 
                                          //FatherNameEn= b.FatherNameEn,
                                          //GrandFatherName= b.GrandFatherName,
                                          //GranfatherNameEn= b.GrandFatherNameEn,
                                          //DobText= b.DateOfBirth.ToShortDateString(),
                                          //DobShamsiText= PersianDate.ToPersianDate(b.DateOfBirth),
                                          //PlaceOfBirthCountryName= p.BirthCountry.Title,
                                          //PlaceOfBirthCountryNameEn= p.BirthCountry.TitleEn,
                                          //PlaceOfBirthProvinceName= p.BirthProvince.Title,
                                          //PlaceOfBirthProviceNameEn= p.BirthProvince.TitleEn,
                                          //PlaceOfBirthDistrictName= a.District.Title,
                                          //PlaceOfBirthDistrictNameEn = a.District.TitleEn,
                                          //PlaceOfBirthVillage = a.Village,
                                          //MaritalStatusNameEn= p.MaritalStatus.NameEn,
                                          //MaritalStatusName= p.MaritalStatus.Name,
                                          //GenderName= p.Gender.Name,
                                          //GenderNameEn= p.Gender.Code,
                                          //ResidenceCountryName = p.ResidenceCountry.Title,
                                          //ResidenceCountryNameEn = p.ResidenceCountry.TitleEn,
                                          //OtherNationalityName=p.OtherNationality.Title,
                                          //OtherNationalityNameEn= p.OtherNationality.TitleEn,
                                          //Height= p.Height,
                                          //HairColorName= p.HairColor.Name,
                                          //HairColorNameEn=p.HairColor.NameEn,
                                          //EyeColorName= p.EyeColor.Name,
                                          //EyeColorNameEn= p.EyeColor.NameEn,
                                          //OtherDetails= p.OtherDetail,
                                          //CountryName= a.Country.Title,
                                          //CountyNameEn= a.Country.TitleEn,
                                          //ProviceNameEn= a.Province.TitleEn,
                                          //ProvinceName= a.Province.Title,
                                          //DistrictName= a.District.Title,
                                          //DistrictNameEn= a.District.TitleEn,
                                          //Village= a.Village,
                                          ////PermanentCountryName= a.Country.Title/*.Where(a.AddressTypeId==2)*/,
                                          ////PermanentCountryNameEn= a.Country.TitleEn/*.Where(a.AddressTypeId==2)*/,
                                          ////PermanentProvinceName= a.Province.Title,
                                          ////PermanentProvinceNameEn= a.Province.TitleEn,
                                          ////PermanentDistrictName= a.District.Title,
                                          ////PermanentDistrictNameEn= a.District.TitleEn,
                                          ////Permanentvillage= a.Village,
                                          //Email= b.Email,
                                          //PhoneNumber= b.PhoneNumber,
                                          //OccupationName= pa.ActiveJob.Occupation.Title,
                                          //OccupationNameEn= pa.ActiveJob.Occupation.TitleEn,
                                          //Employer= pa.ActiveJob.Employer,
                                          //EmployerAddress=pa.ActiveJob.EmployerAddress,
                                          //PreviousEmployer= pa.ActiveJob.PrevEmployer,
                                          //PreviousEmployerAddress= pa.ActiveJob.PrevEmployerAddress,
                                          //PassportTypeName= pa.PassportType.Name,
                                          //PassportTypeNameEn= pa.PassportType.Name,
                                          ////PassportIssuePlaceName= pa.Office.Name,
                                          ////PassportIssuePlaceNameEn= pa.Office.NameEn,
                                          //PhotoPath= pa.PhotoPath,
                                          //SignaturePath= pa.SignaturePath,
                                          //ProfileCode= p.Code,
                                          //ProfileId= p.Id,
                                          //AddressTypeId= a.AddressTypeId
                                      }).ToListAsync();
            var filepath = HostingEnv.WebRootPath + "\\E:\\Formats\\Updated Passport Form.xlsx";
            byte[] bin;
            if (File.Exists(filepath))
            {
                FileInfo file = new FileInfo(filepath);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorksheet sheet = excelPackage.Workbook.Worksheets["Sheet2"];
                    sheet.Cells[4, 6, 4, 11].Value = searchresult[0].FirstName;
                    sheet.Cells[4, 12, 4, 17].Value = searchresult[0].LastName;
                    sheet.Cells[5, 6, 5, 11].Value = searchresult[0].FatherName;
                    sheet.Cells[5, 12, 5, 17].Value = searchresult[0].CDistrictName;
                    //sheet.Cells[6, 6, 6, 11].Value = searchresult[0].NameEn;
                    //sheet.Cells[6, 12, 6, 17].Value = searchresult[0].Name;
                    //sheet.Cells[7, 6, 7, 11].Value = searchresult[0].FatherNameEn;
                    //sheet.Cells[7, 12, 7, 17].Value = searchresult[0].FatherName;
                    //sheet.Cells[8, 6, 8, 11].Value = searchresult[0].GranfatherNameEn;
                    //sheet.Cells[8, 12, 8, 17].Value = searchresult[0].GrandFatherName;
                    //sheet.Cells[9, 6, 10, 11].Value = searchresult[0].DobText;
                    //sheet.Cells[9, 12, 10, 17].Value = searchresult[0].DobShamsiText;
                    //sheet.Cells[12, 6, 12, 11].Value = searchresult[0].PlaceOfBirthCountryNameEn;
                    //sheet.Cells[12, 12, 12, 17].Value = searchresult[0].PlaceOfBirthCountryName;
                    //sheet.Cells[13, 6, 13, 11].Value = searchresult[0].PlaceOfBirthProviceNameEn;
                    //sheet.Cells[13, 12, 13, 17].Value = searchresult[0].PlaceOfBirthProvinceName;
                    //sheet.Cells[14, 6, 14, 11].Value = address[0].District.TitleEn;
                    //sheet.Cells[14, 12, 14, 17].Value = address[0].District.Title;
                    //sheet.Cells[15, 6, 15, 11].Value = address[0].Village;
                    //sheet.Cells[15, 12, 15, 17].Value = address[0].Village;
                    //sheet.Cells[17, 6, 17, 11].Value = searchresult[0].MaritalStatusNameEn;
                    //sheet.Cells[17, 12, 17, 17].Value = searchresult[0].MaritalStatusName;
                    //sheet.Cells[18, 6, 18, 11].Value = searchresult[0].GenderNameEn;
                    //sheet.Cells[18, 12, 18, 17].Value = searchresult[0].GenderName;
                    //sheet.Cells[20, 6, 20, 11].Value = searchresult[0].ResidenceCountryNameEn;
                    //sheet.Cells[20, 12, 20, 17].Value = searchresult[0].ResidenceCountryName;
                    //sheet.Cells[21, 6, 21, 11].Value = searchresult[0].OtherNationalityNameEn;
                    //sheet.Cells[21, 12, 21, 17].Value = searchresult[0].OtherNationalityName;
                    //sheet.Cells[22, 6, 22, 11].Value = searchresult[0].Height + " cm";
                    //sheet.Cells[22, 12, 22, 17].Value = searchresult[0].Height + " سانتی متر";
                    //sheet.Cells[23, 6, 23, 11].Value = searchresult[0].HairColorNameEn;
                    //sheet.Cells[23, 12, 23, 17].Value = searchresult[0].HairColorName;
                    //sheet.Cells[24, 6, 24, 11].Value = searchresult[0].EyeColorNameEn;
                    //sheet.Cells[24, 12, 24, 17].Value = searchresult[0].EyeColorName;
                    //sheet.Cells[26, 6, 26, 11].Value = searchresult[0].OtherNationalityNameEn;
                    //sheet.Cells[26, 12, 26, 17].Value = searchresult[0].OtherNationalityName;
                    //sheet.Cells[28, 6, 28, 11].Value = searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().CountyNameEn + " " + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().ProviceNameEn + " "
                    //    + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().DistrictNameEn + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().Village;
                    //sheet.Cells[28, 12, 28, 17].Value = searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().CountryName + " " + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().ProvinceName + " "
                    //   + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().DistrictName + searchresult.Where(e => e.AddressTypeId == 2).FirstOrDefault().Village;
                    //sheet.Cells[29, 6, 29, 11].Value = searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().CountyNameEn + " " + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().ProviceNameEn + " "
                    //    + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().DistrictNameEn + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().Village;

                    //sheet.Cells[29, 12, 29, 17].Value = searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().CountryName + " " + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().ProvinceName + " "
                    //   + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().DistrictName + searchresult.Where(e => e.AddressTypeId == 1).FirstOrDefault().Village;

                    //sheet.Cells[30, 6, 30, 11].Value = searchresult[0].Email;
                    //sheet.Cells[30, 12, 30, 17].Value = searchresult[0].Email;
                    //sheet.Cells[31, 6, 31, 11].Value = searchresult[0].PhoneNumber;
                    //sheet.Cells[31, 12, 31, 17].Value = searchresult[0].PhoneNumber;
                    //sheet.Cells[36, 6, 36, 11].Value = searchresult[0].OccupationNameEn;
                    //sheet.Cells[36, 12, 36, 17].Value = searchresult[0].OccupationName;
                    //sheet.Cells[37, 6, 37, 11].Value = searchresult[0].Employer;
                    //sheet.Cells[37, 12, 37, 17].Value = searchresult[0].Employer;
                    //sheet.Cells[38, 6, 38, 11].Value = searchresult[0].EmployerAddress;
                    //sheet.Cells[38, 12, 38, 17].Value = searchresult[0].EmployerAddress;
                    //sheet.Cells[39, 6, 39, 11].Value = searchresult[0].PreviousEmployer;
                    //sheet.Cells[39, 12, 39, 17].Value = searchresult[0].PreviousEmployer;
                    //sheet.Cells[40, 6, 40, 11].Value = searchresult[0].PreviousEmployerAddress;
                    //sheet.Cells[40, 12, 40, 17].Value = searchresult[0].PreviousEmployerAddress;
                    //sheet.Cells[42, 6, 42, 11].Value = searchresult[0].PassportTypeNameEn;
                    //sheet.Cells[42, 12, 42, 17].Value = searchresult[0].PassportTypeName;

                    //ExcelPicture pic = sheet.Drawings.AddPicture("barcode", BarcodeGenerator.Generate(searchresult[0].ProfileCode));
                    //pic.SetPosition(120, 1);

                    //Image ApplicantSignature = Image.FromFile(Config.SignaturePath + searchresult[0].SignaturePath);
                    //ExcelPicture signature = sheet.Drawings.AddPicture("Y", ApplicantSignature);
                    //signature.SetSize(295, 300);
                    //signature.SetPosition(53, 0, 5, 0);

                    //Image Applicantphoto = Image.FromFile(Config.ImagePath + searchresult[0].PhotoPath);
                    //ExcelPicture Photo = sheet.Drawings.AddPicture("x", Applicantphoto);
                    //Photo.SetSize(295, 300);
                    //Photo.SetPosition(53, 0, 11, 0);

                    sheet.Cells[55, 6, 55, 11].Value = DateTime.Now.ToShortDateString();
                    sheet.Cells[55, 12, 55, 17].Value = PersianDate.ToPersianDate(DateTime.Now);
                    
                    //sheet.Protection.IsProtected = true;
                    //sheet.Protection.SetPassword("P@33word");
                    //sheet.Protection.AllowEditObject = false;  
                    bin = excelPackage.GetAsByteArray();
                }
            }
            else
            {
                bin = null;
                throw new Exception("x");
            }
            return bin;

        }
    }
}
