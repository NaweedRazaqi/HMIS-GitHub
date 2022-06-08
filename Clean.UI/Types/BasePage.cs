using Clean.UI.Utilities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.UI.Types
{
    public class BasePage : PageModel
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        //private IConfiguration _configuration;
        //public BasePage(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        [BindProperty]
        public string PageID { get; set; }
        
        public List<SelectListItem> ListOfTables { get; set; }
        public List<SelectListItem> ListOfBlackListReasons { get; set; }
        public List<SelectListItem> ListOfDisabledReasons { get; set; }
        public List<SelectListItem> ListOfAttachmentType { get; set; }
        public List<SelectListItem> ListOfPaymentMethod { get; set; }
        public List<SelectListItem> ListOfRequestType { get; set; }
        public List<SelectListItem> ListOfPaymentPenalty { get; set; }
        public List<SelectListItem> ListOfDiscount { get; set; }
        public List<SelectListItem> ListOfPaymentCategory { get; set; }
        public List<SelectListItem> ListOfPassportType { get; set; }
        public List<SelectListItem> ListOfDiscountType { get; set; }
        public List<SelectListItem> ListOfCrimeType { get; set; }
        public List<SelectListItem> ListOfOccupation { get; set; }
        public List<SelectListItem> ListOfAddressType { get; set; }
        public List<SelectListItem> ListOfTitles { get; set; }
        public List<SelectListItem> ListOfEyeColors { get; set; }
        public List<SelectListItem> ListOfHairColors { get; set; }
        public List<SelectListItem> ListOfCountry { get; set; }
        public List<SelectListItem> ListOfProvinces { get; set; }
        public List<SelectListItem> ListOfCurrency { get; set; }
        public List<SelectListItem> ListOfOfficeTypes { get; set; }
        public List<SelectListItem> ListOfOffices { get; set; }
        public List<SelectListItem> ListOfProcessesConnection { get; set; }
        public List<SelectListItem> ListOfScreens { get; set; }
        public List<SelectListItem> ListOfRoles { get; set; }
        public List<SelectListItem> ListOfStatuses { get; set; }
        public List<SelectListItem> ListOfCalculation { get; set; }
        public List<SelectListItem> ListOfFiscalYears { get; set; }
        public List<SelectListItem> ListOfHeritageJobs { get; set; }
        public List<SelectListItem> ListOfEventReasons { get; set; }
        public List<SelectListItem> ListOfLawyerTypes { get; set; }
        public List<SelectListItem> ListOfAppReasons { get; set; }
        public List<SelectListItem> ListOfCategoryTypes { get; set; }
        public List<SelectListItem> ListOfMaritalStatus { get; set; }
        public List<SelectListItem> ListOfGenders { get; set; }
        public List<SelectListItem> ListOfHajStatus { get; set; }
        public List<SelectListItem> ListOfHajjProcessStatus { get; set; }
        public List<SelectListItem> ListOfEducationDegree { get; set; }
        public List<SelectListItem> Marks { get; set; }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Zones { get; set; }
        public List<SelectListItem> ListCreteria { get; set; }
        public List<SelectListItem> ListOfStudyField { get; set; }
        public List<SelectListItem> ListOfLocations { get; set; }
        public List<SelectListItem> ListOfUniversities { get; set; }
        public List<SelectListItem> ListOfBloodGroups { get; set; }
        public List<SelectListItem> ListOfEthnicities { get; set; }
        public List<SelectListItem> ListOfReligions { get; set; }
        public List<SelectListItem> ListOfLanguages { get; set; }
        public List<SelectListItem> ListOfJobStatus { get; set; }
        public List<SelectListItem> ListOfResult { get; set; }
        public List<SelectListItem> ListOfRanks { get; set; }
        public List<SelectListItem> ListOfBanks { get; set; }
        public List<SelectListItem> ListOfOrders { get; set; }
        public List<SelectListItem> ListOfTicketDiscount { get; set; }
        public List<SelectListItem> ListOfTicketorder { get; set; }
        public List<SelectListItem> ListOfOrganizationType { get; set; }
        public List<SelectListItem> ListOfCertification { get; set; }
        public List<SelectListItem> ListOfExperienceType { get; set; }
        public List<SelectListItem> ListOfRelationShip { get; set; }
        public List<SelectListItem> ListOfExpertise { get; set; }
        public List<SelectListItem> ListOfSkillType { get; set; }
        public List<SelectListItem> ListOfDistricts { get; set; }
        public List<SelectListItem> ListOfEducationLevels { get; set; }
        public List<SelectListItem> ListOfStatus { get; set; }
        public List<SelectListItem> ListOfAssetType { get; set; }
        public List<SelectListItem> ListOfReferenceType { get; set; }
        public List<SelectListItem> ListOfDocumentTypes { get; set; }
        public List<SelectListItem> ListOfDocumentTypesD { get; set; }
        public List<SelectListItem> ListOfPublicationType { get; set; }
        public List<SelectListItem> ListOfOrganization { get; set; }
        public List<SelectListItem> ListOfJobTitle { get; set; }
        public List<SelectListItem> ListOfOrgUnit { get; set; }
        public List<SelectListItem> ListOfSalaryType { get; set; }
        public List<SelectListItem> ListOfReportTo { get; set; }
        public List<SelectListItem> ListOfPlanType { get; set; }
        public List<SelectListItem> ListOfVisaType { get; set; }
        public List<SelectListItem> ListOfPositionType { get; set; }
        public List<SelectListItem> ListOfMilitaryServiceType { get; set; }
        public List<SelectListItem> ListOfEventType { get; set; }
        public List<SelectListItem> ListOfPerson { get; set; }
        public List<SelectListItem> ListOfPosition { get; set; }
        public List<SelectListItem> ListOfProcesses { get; set; }
        public List<SelectListItem> ListOfPersianYears { get; set; }
        public List<SelectListItem> ListOfWorkAreas { get; set; }
        public List<SelectListItem> ListOfserviecetype { get; set; }
        public List<SelectListItem> ListOfCandidateTypes { get; set; }
        public List<SelectListItem> ListOfSpecialEntity { get; set; }
        public List<SelectListItem> ListOfCandidate { get; set; }
        public List<SelectListItem> ListOfEmara { get; set; }
        public List<SelectListItem> ListEmaraType { get; set; }
        public List<SelectListItem> ListEmaraZoneType { get; set; }
        public List<SelectListItem> ListOfLanguage { get; set; }
        public List<SelectListItem> ListOfSpecialEntityType { get; set; }
        public List<SelectListItem> ListOfInstallmentType { get; set; }
        public List<SelectListItem> ListOfNazamCandidate { get; set; }
        public List<SelectListItem> ListOfMosque { get; set; }
        public List<SelectListItem> ListOfCommitee { get; set; }
        public List<SelectListItem> ListOfExamResult { get; set; }
        public List<SelectListItem> ListOfStatusType { get; set; }
        public List<SelectListItem> ListOfAirLine { get; set; }
        public List<SelectListItem> ListOfMutamid { get; set; }
        public List<SelectListItem> ListOfExpenseCenters { get; set; }
        public List<SelectListItem> ListOfEmployeeContractType { get; set; }
        public List<SelectListItem> ListOfRelatives { get; set; }
        public List<SelectListItem> ListOfHajjYear { get; set; }
        public List<SelectListItem> ListOfContract { get; set; }
        public List<SelectListItem> ListOfExpenseTypes { get; set; }

        /// <summary>
        /// the ID of the Screen from the query string parameter
        /// </summary>
        public int RequestScreenID
        {
            get
            {
                return Convert.ToInt32(EncryptionHelper.Decrypt(Request.Query["p"]));
            }
        }


    }
}
