using App.Domain.Entity.doc;
using App.Domain.Entity.Evaluation;
using App.Domain.Entity.look;
using App.Domain.Entity.prf;
using App.Domain.Entity.rep;
using App.Domain.Entity.Reports;
using App.Domain.Entity.Views;
using Clean.Common;
using Clean.Persistence.Context;
using Clean.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Persistence.Context
{
    public class AppDbContext : BaseContext
    {
        public static readonly ILoggerFactory DbLogger = LoggerFactory.Create(ex => ex.AddConsole());

        public AppDbContext(DbContextOptions<AppDbContext> options, UserManager<AppUser> manager) : base(options, manager)
        {

        }
        public virtual DbSet<Clean.Domain.Entity.look.Country> Countries { get; set; }
        public virtual DbSet<Clean.Domain.Entity.look.District> Districts { get; set; }
        public virtual DbSet<Clean.Domain.Entity.look.Province> Provinces { get; set; }
        public virtual DbSet<Clean.Domain.Entity.look.Office> Offices { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Nerecords> Nerecords { get; set; }
        public virtual DbSet<EvCreteria> EvCreterias { get; set; }
        public virtual DbSet<NazemExperience> NazemExperiences { get; set; }
        public virtual DbSet<Evzone> Evzones { get; set; }
        public virtual DbSet<Evcategory> Evcategories { get; set; }
        public virtual DbSet<Marks>  Marks { get; set; }
        public virtual DbSet<EducationDegree> Educationdegrees { get; set; }
        public virtual DbSet<FieldofStudy> Studyfields { get; set; }
        public virtual DbSet<Ethnicity> Ethnicities { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<HajiStatus> HajiStatuses { get; set; }
        public virtual DbSet<Dbobject> Dbobject { get; set; }
        public virtual DbSet<DbobjectObject> DbobjectObject { get; set; }
        public virtual DbSet<HajjprocessStatus> HajjprocessStatuses { get; set; }
        public virtual DbSet<Location> Locations{ get; set; }
        public virtual DbSet<University> Universities{ get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses{ get; set; }
        public virtual DbSet<Religion> Religions{ get; set; }
        public virtual DbSet<Status> Statuses{ get; set; }
        public virtual DbSet<Year> Years{ get; set; }
        public virtual DbSet<VisaType> VisaType{ get; set; }
        public virtual DbSet<BloodGroup> BloodGroups{ get; set; }
        public virtual DbSet<CandidateTypes> CandidateTypes{ get; set; }
        public virtual DbSet<SpecialEntity> SpecialEntities{ get; set; }
        public virtual DbSet<Candidate> Candidates{ get; set; }
        public virtual DbSet<ExecelReport> ExecelReports{ get; set; }
        public virtual DbSet<HajiMahramdetails> HajiMahramdetails { get; set; }
        public virtual DbSet<SelectQueue> SelectQueues{ get; set; }
        public virtual DbSet<HajjiSelection> HajjSelections{ get; set; }
        public virtual DbSet<Relation> Relations{ get; set; }
        public virtual DbSet<Address> Addresses{ get; set; }
        public virtual DbSet<Language>  Languages{ get; set; }
        public virtual DbSet<Passport> Passports{ get; set; }
        public virtual DbSet<PassportType> PassportTypes{ get; set; }
        public virtual DbSet<Job> Jobs{ get; set; }
        public virtual DbSet<Relative> Relatives{ get; set; }
        public virtual DbSet<SpecialEntityType> SpecialEntityTypes{ get; set; }
        public virtual DbSet<Installment> Installments{ get; set; }
        public virtual DbSet<HajjYearlyFee> HajjYearlyFees{ get; set; }
        public virtual DbSet<Installments> view{ get; set; }
        public virtual DbSet<Bank> Banks{ get; set; }
        public virtual DbSet<Rank> Ranks{ get; set; }
             public virtual DbSet<EmaraZoneType> EmaraZoneTypes{ get; set; }
        public virtual DbSet<EmaraType> EmaraTypes{ get; set; }
        public virtual DbSet<Order> Orders{ get; set; }
        public virtual DbSet<TicketOrder> TicketOrders{ get; set; }
        public virtual DbSet<TicketDiscount> TicketDiscounts{ get; set; }
        public virtual DbSet<InstallmentType> InstallmentTypes{ get; set; }
        public virtual DbSet<Currency> Currencies{ get; set; }
        public virtual DbSet<HajjYear> HajjYears { get; set; }
        public virtual DbSet<HajyearlyCapacity>  HajyearlyCapacities { get; set; }
        public virtual DbSet<ProvincesCapacity> ProvincesCapacities { get; set; }
        public virtual DbSet<NazamAssignment> NazamAssignments{ get; set; }
        public virtual DbSet<Mosque> Mosques{ get; set; }
        public virtual DbSet<NazamToMosque> NazamToMosques{ get; set; }
        public virtual DbSet<VisaInfo> VisaInfos{ get; set; }
        public virtual DbSet<Commitee> Commitees{ get; set; }
        public virtual DbSet<Exam> Exams{ get; set; }
        public virtual DbSet<ExamResult> ExamResults{ get; set; }
        public virtual DbSet<ExamScore> ExamScores{ get; set; }
        public virtual DbSet<CandidateStatus> CandidateStatuses{ get; set; }
        public virtual DbSet<StatusType> StatusTypes{ get; set; }
        public virtual DbSet<Emara> Emaras{ get; set; }
        public virtual DbSet<HajjiAdditionToEmara> HajjiAdditionToEmaras{ get; set; }
        public virtual DbSet<Qouta>  Qoutas { get; set; }
        public virtual DbSet<TicketInfo> TicketInfos{ get; set; }
        public virtual DbSet<Airline> Airlines{ get; set; }
        public virtual DbSet<MobileCards> MobileCards{ get; set; }
        public virtual DbSet<Mutamids> Mutamids{ get; set; }
        public virtual DbSet<MutamidCashes> MutamidCashes{ get; set; }
        public virtual DbSet<ExpenseCenters> ExpenseCenters{ get; set; }
        public virtual DbSet<MutamidAccounts> MutamidAccounts{ get; set; }
        public virtual DbSet<Wages> Wages{ get; set; }
        public virtual DbSet<MoneyBack> MoneyBacks{ get; set; }
        public virtual DbSet<EmployeeContractTypes> EmployeeContractTypes{ get; set; }
        public virtual DbSet<Contract> Contracts{ get; set; }
        public virtual DbSet<ContractInstallment> ContractInstallments{ get; set; }
        public virtual DbSet<DailyExpense> DailyExpenses{ get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<CancelCandidate> CancelCandidates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseLoggerFactory(DbLogger);
                options.EnableSensitiveDataLogging(true);
                options.UseNpgsql(AppConfig.BaseConnectionString, (opts) =>
                {
                    
                });
            }
            base.OnConfiguring(options);
        }
    }
}
