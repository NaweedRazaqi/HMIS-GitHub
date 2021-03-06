using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clean.UI.model
{
    public partial class HMISContext : DbContext
    {
        public HMISContext()
        {
        }

        public HMISContext(DbContextOptions<HMISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Apportioment> Apportioment { get; set; }
        public virtual DbSet<ApproveInstallments> ApproveInstallments { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Attendence> Attendence { get; set; }
        public virtual DbSet<AttendenceType> AttendenceType { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<CancelCandidate> CancelCandidate { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<CandidateStatus> CandidateStatus { get; set; }
        public virtual DbSet<CandidateTypes> CandidateTypes { get; set; }
        public virtual DbSet<Commitee> Commitee { get; set; }
        public virtual DbSet<CommiteeMember> CommiteeMember { get; set; }
        public virtual DbSet<CommiteeType> CommiteeType { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractInstallment> ContractInstallment { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<DailyExpense> DailyExpense { get; set; }
        public virtual DbSet<Dbobject> Dbobject { get; set; }
        public virtual DbSet<DbobjectObject> DbobjectObject { get; set; }
        public virtual DbSet<DisableType> DisableType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<DocumentType1> DocumentType1 { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Education1> Education1 { get; set; }
        public virtual DbSet<EducationDegree> EducationDegree { get; set; }
        public virtual DbSet<Emara> Emara { get; set; }
        public virtual DbSet<EmployeeContractTypes> EmployeeContractTypes { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<Evcategory> Evcategory { get; set; }
        public virtual DbSet<EventReason> EventReason { get; set; }
        public virtual DbSet<Evzone> Evzone { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestion { get; set; }
        public virtual DbSet<ExamResult> ExamResult { get; set; }
        public virtual DbSet<ExamScore> ExamScore { get; set; }
        public virtual DbSet<ExecelReport> ExecelReport { get; set; }
        public virtual DbSet<ExpenseCenters> ExpenseCenters { get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<FieldofStudy> FieldofStudy { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<HajiMahramdetails> HajiMahramdetails { get; set; }
        public virtual DbSet<HajiStatus> HajiStatus { get; set; }
        public virtual DbSet<HajjYear> HajjYear { get; set; }
        public virtual DbSet<HajjiSelection> HajjiSelection { get; set; }
        public virtual DbSet<HajjprocessStatus> HajjprocessStatus { get; set; }
        public virtual DbSet<HajyearlyCapacity> HajyearlyCapacity { get; set; }
        public virtual DbSet<Installment> Installment { get; set; }
        public virtual DbSet<InstallmentType> InstallmentType { get; set; }
        public virtual DbSet<Installments> Installments { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<MinistryRec> MinistryRec { get; set; }
        public virtual DbSet<MobileCards> MobileCards { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<MoneyBack> MoneyBack { get; set; }
        public virtual DbSet<Mosque> Mosque { get; set; }
        public virtual DbSet<MutamidAccounts> MutamidAccounts { get; set; }
        public virtual DbSet<MutamidCashes> MutamidCashes { get; set; }
        public virtual DbSet<Mutamids> Mutamids { get; set; }
        public virtual DbSet<NazamAssignment> NazamAssignment { get; set; }
        public virtual DbSet<NazamSalary> NazamSalary { get; set; }
        public virtual DbSet<NazamToMosque> NazamToMosque { get; set; }
        public virtual DbSet<Nerecords> Nerecords { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationType> NotificationType { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<OperationType> OperationType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Passport> Passport { get; set; }
        public virtual DbSet<PassportType> PassportType { get; set; }
        public virtual DbSet<PerYearCpacity> PerYearCpacity { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessConnection> ProcessConnection { get; set; }
        public virtual DbSet<ProcessTracking> ProcessTracking { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<ProvincesCapacity> ProvincesCapacity { get; set; }
        public virtual DbSet<Qouta> Qouta { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<RegistrationType> RegistrationType { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<Relative> Relative { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<ReturnMoney> ReturnMoney { get; set; }
        public virtual DbSet<RoleScreen> RoleScreen { get; set; }
        public virtual DbSet<Screen> Screen { get; set; }
        public virtual DbSet<ScreenDocument> ScreenDocument { get; set; }
        public virtual DbSet<SelectQueue> SelectQueue { get; set; }
        public virtual DbSet<SpecialEntity> SpecialEntity { get; set; }
        public virtual DbSet<SpecialEntityType> SpecialEntityType { get; set; }
        public virtual DbSet<Sscandidate> Sscandidate { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }
        public virtual DbSet<TicketDiscount> TicketDiscount { get; set; }
        public virtual DbSet<TicketInfo> TicketInfo { get; set; }
        public virtual DbSet<TicketOrder> TicketOrder { get; set; }
        public virtual DbSet<VCandidate> VCandidate { get; set; }
        public virtual DbSet<VisaInfo> VisaInfo { get; set; }
        public virtual DbSet<Wages> Wages { get; set; }
        public virtual DbSet<Year> Year { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server = localhost; Database= HMIS; password= GresPostAql; port= 5432; Username= postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .IsUnique();

                entity.HasIndex(e => e.CdistrictId)
                    .HasName("fki_FK_Address_Location_CDistrictID");

                entity.HasIndex(e => e.CprovinceId)
                    .HasName("fki_FK_Address_Location_LocationID");

                entity.HasIndex(e => e.PdistrictId)
                    .HasName("fki_FK_Address_Location_PDistrictID");

                entity.HasIndex(e => e.PprovinceId)
                    .HasName("fki_FK_Address_Location_PProvinceID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CdistrictId).HasColumnName("CDistrictID");

                entity.Property(e => e.CfullAdd).HasColumnName("CFullAdd");

                entity.Property(e => e.CprovinceId).HasColumnName("CProvinceID");

                entity.Property(e => e.Mobile).HasColumnType("character varying");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.PdistrictId).HasColumnName("PDistrictID");

                entity.Property(e => e.PfullAdd).HasColumnName("PFullAdd");

                entity.Property(e => e.Phone).HasColumnType("character varying");

                entity.Property(e => e.PprovinceId).HasColumnName("PProvinceID");

                entity.HasOne(d => d.Candidate)
                    .WithOne(p => p.Address)
                    .HasForeignKey<Address>(d => d.CandidateId);

                entity.HasOne(d => d.Cdistrict)
                    .WithMany(p => p.AddressCdistrict)
                    .HasForeignKey(d => d.CdistrictId);

                entity.HasOne(d => d.Cprovince)
                    .WithMany(p => p.AddressCprovince)
                    .HasForeignKey(d => d.CprovinceId);

                entity.HasOne(d => d.Pdistrict)
                    .WithMany(p => p.AddressPdistrict)
                    .HasForeignKey(d => d.PdistrictId);

                entity.HasOne(d => d.Pprovince)
                    .WithMany(p => p.AddressPprovince)
                    .HasForeignKey(d => d.PprovinceId);
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("Airline", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Apportioment>(entity =>
            {
                entity.ToTable("Apportioment", "prf");

                entity.HasIndex(e => e.DistrictsId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DistrictsId).HasColumnName("DistrictsID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Districts)
                    .WithMany(p => p.Apportioment)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apportionment_Location_DistrictsID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Apportioment)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apportionment_Year_YearID");
            });

            modelBuilder.Entity<ApproveInstallments>(entity =>
            {
                entity.ToTable("ApproveInstallments", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ApproveInstallments)
                    .HasForeignKey(d => d.CandidateId);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.HasIndex(e => e.OfficeId);

                entity.HasIndex(e => e.OrganizationId);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.OfficeId).HasColumnName("OfficeID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Attendence>(entity =>
            {
                entity.ToTable("Attendence", "prf");

                entity.HasIndex(e => e.AttendenceTypeId);

                entity.HasIndex(e => e.NazamId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttendenceTypeId).HasColumnName("AttendenceTypeID");

                entity.Property(e => e.NazamId).HasColumnName("NazamID");

                entity.HasOne(d => d.AttendenceType)
                    .WithMany(p => p.Attendence)
                    .HasForeignKey(d => d.AttendenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendence_AttendenceType_AttendenceTypeID");

                entity.HasOne(d => d.Nazam)
                    .WithMany(p => p.Attendence)
                    .HasForeignKey(d => d.NazamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AttendenceType>(entity =>
            {
                entity.ToTable("AttendenceType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("Audit", "au");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DbContextObject).HasMaxLength(100);

                entity.Property(e => e.DbObjectName).HasMaxLength(100);

                entity.Property(e => e.OperationTypeId).HasColumnName("OperationTypeID");

                entity.Property(e => e.RecordId)
                    .HasColumnName("RecordID")
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValueAfter).HasColumnType("character varying");

                entity.Property(e => e.ValueBefore).HasColumnType("character varying");

                entity.HasOne(d => d.OperationType)
                    .WithMany(p => p.Audit)
                    .HasForeignKey(d => d.OperationTypeId)
                    .HasConstraintName("audit_fk");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.bloodgroup_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CancelCandidate>(entity =>
            {
                entity.ToTable("CancelCandidate", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("fki_FK_CancelCandidate_Candidate_CandidateID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CancelCandidate)
                    .HasForeignKey(d => d.CandidateId);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate", "prf");

                entity.HasIndex(e => e.BloodGroupId);

                entity.HasIndex(e => e.CandidateTypeId);

                entity.HasIndex(e => e.DocumentTypeId)
                    .HasName("fki_FK_cand_doctype");

                entity.HasIndex(e => e.FirstName)
                    .HasName("fnam_idx");

                entity.HasIndex(e => e.GenderId);

                entity.HasIndex(e => e.HajiStatusId)
                    .HasName("fki_fk_cand_hajjprocess");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("fki_fk_candidat_language");

                entity.HasIndex(e => e.LastName)
                    .HasName("id_idx");

                entity.HasIndex(e => e.MahramId);

                entity.HasIndex(e => e.MaritalStatusId);

                entity.HasIndex(e => e.NazamCandidateId)
                    .HasName("fki_FK_Candidate_Candidate_NazamCandidateID");

                entity.HasIndex(e => e.RelationshipId);

                entity.HasIndex(e => e.ReligionId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");

                entity.Property(e => e.CandidateTypeId).HasColumnName("CandidateTypeID");

                entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.HajiStatusId).HasColumnName("HajiStatusID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.MahramId).HasColumnName("MahramID");

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasColumnType("character varying");

                entity.Property(e => e.NazamCandidateId).HasColumnName("NazamCandidateID");

                entity.Property(e => e.NazamCategoryId).HasColumnName("NazamCategoryID");

                entity.Property(e => e.PhotoPath).HasColumnType("character varying");

                entity.Property(e => e.Prefix).HasColumnType("character varying");

                entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.BloodGroupId);

                entity.HasOne(d => d.CandidateType)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.CandidateTypeId)
                    .HasConstraintName("FK_Candidate_CandidateType_CandidateTypeID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.GenderId);

                entity.HasOne(d => d.HajiStatus)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.HajiStatusId)
                    .HasConstraintName("FK_cand_HajiStatus");

                entity.HasOne(d => d.HajiStatusNavigation)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.HajiStatusId)
                    .HasConstraintName("fk_cand_hajjprocess");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_candidat_language");

                entity.HasOne(d => d.Mahram)
                    .WithMany(p => p.InverseMahram)
                    .HasForeignKey(d => d.MahramId);

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("fk_candidate_maritalstatus");

                entity.HasOne(d => d.NazamCandidate)
                    .WithMany(p => p.InverseNazamCandidate)
                    .HasForeignKey(d => d.NazamCandidateId);

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.RelationshipId)
                    .HasConstraintName("FK_Candidate_Relationship_RelationshipID");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.ReligionId);
            });

            modelBuilder.Entity<CandidateStatus>(entity =>
            {
                entity.ToTable("CandidateStatus", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("IX_Status_CandidateID");

                entity.HasIndex(e => e.CprovincesId)
                    .HasName("IX_Status_CProvincesID");

                entity.HasIndex(e => e.StatusTypeId)
                    .HasName("IX_Status_StatusTypeID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CprovincesId).HasColumnName("CProvincesID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.StatusTypeId).HasColumnName("StatusTypeID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateStatus)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Candidate_CandidateID");

                entity.HasOne(d => d.Cprovinces)
                    .WithMany(p => p.CandidateStatus)
                    .HasForeignKey(d => d.CprovincesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_Location_CProvincesID");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.CandidateStatus)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_StatusType_StatusTypeId");
            });

            modelBuilder.Entity<CandidateTypes>(entity =>
            {
                entity.ToTable("CandidateTypes", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Commitee>(entity =>
            {
                entity.ToTable("Commitee", "prf");

                entity.HasIndex(e => e.CommiteeTypeId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommiteeTypeId).HasColumnName("CommiteeTypeID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.CommiteeType)
                    .WithMany(p => p.Commitee)
                    .HasForeignKey(d => d.CommiteeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CommiteeMember>(entity =>
            {
                entity.ToTable("CommiteeMember", "prf");

                entity.HasIndex(e => e.CommiteeId);

                entity.HasIndex(e => e.GenderId);

                entity.HasIndex(e => e.OrganizationId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommiteeId).HasColumnName("CommiteeID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.HasOne(d => d.Commitee)
                    .WithMany(p => p.CommiteeMember)
                    .HasForeignKey(d => d.CommiteeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.CommiteeMember)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.CommiteeMember)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CommiteeType>(entity =>
            {
                entity.ToTable("CommiteeType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract", "prf");

                entity.HasIndex(e => e.ExpenseCenterId);

                entity.HasIndex(e => e.LocationId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpenseCenterId).HasColumnName("ExpenseCenterID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.HasOne(d => d.ExpenseCenter)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ExpenseCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_ExpenseCenter_ExpenseCenterID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ContractInstallment>(entity =>
            {
                entity.ToTable("ContractInstallment", "prf");

                entity.HasIndex(e => e.ContractId);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.ContractInstallment)
                    .HasForeignKey(d => d.ContractId);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.ContractInstallment)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.ContractInstallment)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.TitleEn)
                    .IsRequired()
                    .HasColumnName("TitleEN")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<DailyExpense>(entity =>
            {
                entity.ToTable("DailyExpense", "prf");

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.ExpenseTypeId);

                entity.HasIndex(e => e.MutamidId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConvertedCurrecyId).HasColumnName("ConvertedCurrecyID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.ExpenseTypeId).HasColumnName("ExpenseTypeID");

                entity.Property(e => e.M7date).HasColumnName("M7Date");

                entity.Property(e => e.M7number).HasColumnName("M7Number");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.DailyExpense)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.DailyExpense)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyExpense_ExpenseType_ExpenseTypeID");

                entity.HasOne(d => d.Mutamid)
                    .WithMany(p => p.DailyExpense)
                    .HasForeignKey(d => d.MutamidId)
                    .HasConstraintName("FK_DailyExpense_mutamids_MutamidID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.DailyExpense)
                    .HasForeignKey(d => d.YearId);
            });

            modelBuilder.Entity<Dbobject>(entity =>
            {
                entity.ToTable("DBObject", "rep");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dbname).HasColumnName("DBName");

                entity.Property(e => e.Fkey).HasColumnName("FKey");

                entity.Property(e => e.Pkey).HasColumnName("PKey");
            });

            modelBuilder.Entity<DbobjectObject>(entity =>
            {
                entity.ToTable("DBObjectObject", "rep");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<DisableType>(entity =>
            {
                entity.ToTable("DisableType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.disabletype_seq'::regclass)");

                entity.Property(e => e.DFrom).HasColumnName("D_From");

                entity.Property(e => e.DTo).HasColumnName("D_To");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType", "doc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Category).HasColumnType("character varying");

                entity.Property(e => e.Description).HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<DocumentType1>(entity =>
            {
                entity.ToTable("DocumentType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.documenttype_seq'::regclass)");

                entity.Property(e => e.Category).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("Documents", "doc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DocumentDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DocumentNumber).HasMaxLength(100);

                entity.Property(e => e.DocumentSource).HasMaxLength(100);

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastDownloadDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Root).HasMaxLength(200);

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

                entity.Property(e => e.UploadDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_Documents__FK");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Education", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.education_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Education1>(entity =>
            {
                entity.ToTable("Education", "prf");

                entity.HasIndex(e => e.Candidateid)
                    .HasName("fki_FK_Ed_candidate");

                entity.HasIndex(e => e.Countryid)
                    .HasName("fki_FK_ED_LO");

                entity.HasIndex(e => e.Degreeid)
                    .HasName("fki_FK_ed_deg");

                entity.HasIndex(e => e.Fieldofstudyid)
                    .HasName("fki_FK_ED_Field");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Candidateid).HasColumnName("candidateid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Degreeid)
                    .HasColumnName("degreeid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fieldofstudyid).HasColumnName("fieldofstudyid");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.University)
                    .HasColumnName("university")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Education1)
                    .HasForeignKey(d => d.Candidateid)
                    .HasConstraintName("FK_Ed_candidate");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Education1)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK_ED_LO");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.Education1)
                    .HasForeignKey(d => d.Degreeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ed_deg");

                entity.HasOne(d => d.Fieldofstudy)
                    .WithMany(p => p.Education1)
                    .HasForeignKey(d => d.Fieldofstudyid)
                    .HasConstraintName("FK_ED_Field");
            });

            modelBuilder.Entity<EducationDegree>(entity =>
            {
                entity.ToTable("EducationDegree", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.education_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Emara>(entity =>
            {
                entity.ToTable("Emara", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.LocationId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Emara)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Emara)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Emara)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmployeeContractTypes>(entity =>
            {
                entity.ToTable("EmployeeContractTypes", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Ethnicity>(entity =>
            {
                entity.ToTable("Ethnicity", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Evcategory>(entity =>
            {
                entity.ToTable("EVCategory", "NE");

                entity.HasIndex(e => e.ZoneId)
                    .HasName("fki_FK_categor_Zone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Evcategory)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_categor_Zone");
            });

            modelBuilder.Entity<EventReason>(entity =>
            {
                entity.ToTable("EventReason", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.eventreason_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Evzone>(entity =>
            {
                entity.ToTable("EVZone", "NE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam", "prf");

                entity.HasIndex(e => e.CommiteeId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommiteeId).HasColumnName("CommiteeID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Commitee)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.CommiteeId);
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.ToTable("ExamQuestion", "prf");

                entity.HasIndex(e => e.ExamId);

                entity.HasIndex(e => e.QuestionId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamQuestion)
                    .HasForeignKey(d => d.ExamId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ExamQuestion)
                    .HasForeignKey(d => d.QuestionId);
            });

            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.ToTable("ExamResult", "prf");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ExamScore>(entity =>
            {
                entity.ToTable("ExamScore", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.ExamResultId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ExamResultId).HasColumnName("ExamResultID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ExamScore)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.ExamResult)
                    .WithMany(p => p.ExamScore)
                    .HasForeignKey(d => d.ExamResultId);
            });

            modelBuilder.Entity<ExecelReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExecelReport", "prf");

                entity.Property(e => e.CurrentDistricts).HasMaxLength(100);

                entity.Property(e => e.CurrentProvince).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.GrandFatherName).HasColumnName("GrandFatherName ");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PerminantDistricts).HasMaxLength(100);

                entity.Property(e => e.PerminantProvince).HasMaxLength(100);

                entity.Property(e => e.Religion).HasMaxLength(50);
            });

            modelBuilder.Entity<ExpenseCenters>(entity =>
            {
                entity.ToTable("ExpenseCenters", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ExpenseTypes>(entity =>
            {
                entity.ToTable("ExpenseTypes", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<FieldofStudy>(entity =>
            {
                entity.ToTable("FieldofStudy", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.gender_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HajiMahramdetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HajiMahramdetails", "prf");

                entity.Property(e => e.Genders).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mahramid).HasColumnName("mahramid");

                entity.Property(e => e.Mahramlast).HasColumnName("mahramlast");

                entity.Property(e => e.Mahramname).HasColumnName("mahramname");

                entity.Property(e => e.Relegions).HasMaxLength(50);
            });

            modelBuilder.Entity<HajiStatus>(entity =>
            {
                entity.ToTable("HajiStatus", "look");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<HajjYear>(entity =>
            {
                entity.ToTable("HajjYear", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.ProvincesId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.ProvincesId).HasColumnName("ProvincesID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.HajjYear)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Provinces)
                    .WithMany(p => p.HajjYear)
                    .HasForeignKey(d => d.ProvincesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HajjYear_Location_LocationID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.HajjYear)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<HajjiSelection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HajjiSelection", "prf");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Hajjid).HasColumnName("HAJJID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Religion).HasMaxLength(50);

                entity.Property(e => e.YearId).HasColumnName("YearID");
            });

            modelBuilder.Entity<HajjprocessStatus>(entity =>
            {
                entity.ToTable("HajjprocessStatus", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Dari).HasColumnType("character varying");

                entity.Property(e => e.Name).HasColumnType("character varying");

                entity.Property(e => e.Pashto).HasColumnType("character varying");
            });

            modelBuilder.Entity<HajyearlyCapacity>(entity =>
            {
                entity.ToTable("HajyearlyCapacity", "prf");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.HajyearlyCapacity)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_HRC_Year");
            });

            modelBuilder.Entity<Installment>(entity =>
            {
                entity.ToTable("Installment", "prf");

                entity.HasIndex(e => e.BankId);

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.DiscountId)
                    .HasName("fki_Fk_amountdiscount_disc");

                entity.HasIndex(e => e.InstallmentTypeId);

                entity.HasIndex(e => e.OrderId)
                    .HasName("fki_FK_order_orders");

                entity.HasIndex(e => e.OrdererId)
                    .HasName("fki_FK_whosorder_orderer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.InstallmentTypeId).HasColumnName("InstallmentTypeID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrdererId).HasColumnName("OrdererID");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.CandidateId);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("Fk_amountdiscount_disc");

                entity.HasOne(d => d.InstallmentType)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.InstallmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_orders");

                entity.HasOne(d => d.Orderer)
                    .WithMany(p => p.Installment)
                    .HasForeignKey(d => d.OrdererId)
                    .HasConstraintName("FK_whosorder_orderer");
            });

            modelBuilder.Entity<InstallmentType>(entity =>
            {
                entity.ToTable("InstallmentType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Installments>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Installments", "prf");

                entity.Property(e => e.Destricts).HasMaxLength(100);

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasColumnType("character varying");

                entity.Property(e => e.Province).HasMaxLength(100);

                entity.Property(e => e.Religion).HasMaxLength(50);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("fki_FK_Job_Candidate_CandidateID");

                entity.HasIndex(e => e.JobTilteId)
                    .HasName("fki_FK_job_jobtitle");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("fki_FK_job_org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.JobTilteId).HasColumnName("JobTilteID");

                entity.Property(e => e.JobTitle).HasColumnType("character varying");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.JobTilte)
                    .WithMany(p => p.JobJobTilte)
                    .HasForeignKey(d => d.JobTilteId)
                    .HasConstraintName("FK_job_jobtitle");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.JobOrganization)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_job_org");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("JobTitle", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code).HasColumnType("character varying");

                entity.Property(e => e.Dari).HasColumnType("character varying");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasColumnType("character varying");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasMaxLength(50);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Path).HasMaxLength(400);

                entity.Property(e => e.PathDari).HasMaxLength(400);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("MaritalStatus", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.maritalstatus_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.ToTable("Marks", "look");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<MinistryRec>(entity =>
            {
                entity.ToTable("MinistryRec", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.ministryrec_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<MobileCards>(entity =>
            {
                entity.ToTable("MobileCards", "prf");

                entity.HasIndex(e => e.MutamidId)
                    .HasName("IX_mobileCards_MutamidID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

                entity.Property(e => e.SpentFor).HasColumnType("character varying");

                entity.HasOne(d => d.Mutamid)
                    .WithMany(p => p.MobileCards)
                    .HasForeignKey(d => d.MutamidId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_mobileCards_mutamids_MutamidID");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<MoneyBack>(entity =>
            {
                entity.ToTable("MoneyBack", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.HajjYearId);

                entity.HasIndex(e => e.RelativeId);

                entity.HasIndex(e => e.YearId)
                    .HasName("fki_FK_MoneyBack_Year_YearID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CheckedBy).HasColumnName("checkedBy");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.HajjYearId).HasColumnName("HajjYearID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.NumberMaktoobBank).HasColumnName("NumberMaktoob_bank");

                entity.Property(e => e.RelativeId).HasColumnName("RelativeID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.MoneyBack)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.MoneyBack)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.HajjYear)
                    .WithMany(p => p.MoneyBack)
                    .HasForeignKey(d => d.HajjYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Relative)
                    .WithMany(p => p.MoneyBack)
                    .HasForeignKey(d => d.RelativeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MoneyBack)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Mosque>(entity =>
            {
                entity.ToTable("Mosque", "prf");

                entity.HasIndex(e => e.DistrictId)
                    .HasName("fki_FK_Mosque_Location_DistrictID");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("fki_FK_Mosque_Location_ProvinceID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.MosqueDistrict)
                    .HasForeignKey(d => d.DistrictId);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.MosqueProvince)
                    .HasForeignKey(d => d.ProvinceId);
            });

            modelBuilder.Entity<MutamidAccounts>(entity =>
            {
                entity.ToTable("MutamidAccounts", "prf");

                entity.HasIndex(e => e.CurrencyId)
                    .HasName("IX_mutamidAccounts_CurrencyID");

                entity.HasIndex(e => e.MutamidId)
                    .HasName("IX_mutamidAccounts_MutamidID");

                entity.HasIndex(e => e.YearId)
                    .HasName("IX_mutamidAccounts_YearID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.MutamidAccounts)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mutamidAccounts_Currency_CurrencyID");

                entity.HasOne(d => d.Mutamid)
                    .WithMany(p => p.MutamidAccounts)
                    .HasForeignKey(d => d.MutamidId)
                    .HasConstraintName("FK_mutamidAccounts_mutamids_MutamidID");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MutamidAccounts)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mutamidAccounts_Year_YearID");
            });

            modelBuilder.Entity<MutamidCashes>(entity =>
            {
                entity.ToTable("MutamidCashes", "prf");

                entity.HasIndex(e => e.CurrencyId)
                    .HasName("IX_mutamidCashes_CurrencyID");

                entity.HasIndex(e => e.ExpenseCenterId)
                    .HasName("IX_mutamidCashes_ExpenseCenterID");

                entity.HasIndex(e => e.MutamidId)
                    .HasName("IX_mutamidCashes_MutamidID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.ExpenseCenterId).HasColumnName("ExpenseCenterID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.MutamidCashes)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ExpenseCenter)
                    .WithMany(p => p.MutamidCashes)
                    .HasForeignKey(d => d.ExpenseCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MutamidCashes_ExpenseCenter_ExpenseCenterID");

                entity.HasOne(d => d.Mutamid)
                    .WithMany(p => p.MutamidCashes)
                    .HasForeignKey(d => d.MutamidId)
                    .HasConstraintName("FK_mutamidCashes_mutamids_MutamidID");
            });

            modelBuilder.Entity<Mutamids>(entity =>
            {
                entity.ToTable("Mutamids", "prf");

                entity.HasIndex(e => e.DistrictsId)
                    .HasName("IX_mutamids_DistrictsID");

                entity.HasIndex(e => e.ProvincesId)
                    .HasName("IX_mutamids_ProvincesID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DistrictsId).HasColumnName("DistrictsID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ProvincesId).HasColumnName("ProvincesID");

                entity.HasOne(d => d.Districts)
                    .WithMany(p => p.MutamidsDistricts)
                    .HasForeignKey(d => d.DistrictsId);

                entity.HasOne(d => d.Provinces)
                    .WithMany(p => p.MutamidsProvinces)
                    .HasForeignKey(d => d.ProvincesId);
            });

            modelBuilder.Entity<NazamAssignment>(entity =>
            {
                entity.ToTable("NazamAssignment", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.NazamCandidateId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.NazamCandidateId).HasColumnName("NazamCandidateID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.NazamAssignmentCandidate)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.NazamCandidate)
                    .WithMany(p => p.NazamAssignmentNazamCandidate)
                    .HasForeignKey(d => d.NazamCandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<NazamSalary>(entity =>
            {
                entity.ToTable("NazamSalary", "prf");

                entity.HasIndex(e => e.NazamId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NazamId).HasColumnName("NazamID");

                entity.HasOne(d => d.Nazam)
                    .WithMany(p => p.NazamSalary)
                    .HasForeignKey(d => d.NazamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<NazamToMosque>(entity =>
            {
                entity.ToTable("NazamToMosque", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.MosqueId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.MosqueId).HasColumnName("MosqueID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.NazamToMosque)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Mosque)
                    .WithMany(p => p.NazamToMosque)
                    .HasForeignKey(d => d.MosqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Nerecords>(entity =>
            {
                entity.ToTable("NERecords", "NE");

                entity.HasIndex(e => e.Evid)
                    .HasName("fki_FK_record_category");

                entity.HasIndex(e => e.MarkId)
                    .HasName("fki_FK_NER_Marks");

                entity.HasIndex(e => e.Nid)
                    .HasName("fki_FK_NER_Nazim");

                entity.HasIndex(e => e.ZoneId)
                    .HasName("fki_FK_record_Zone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

                entity.Property(e => e.Evid).HasColumnName("EVID");

                entity.Property(e => e.MarkId).HasColumnName("MarkID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

                entity.Property(e => e.Nid).HasColumnName("NID");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.HasOne(d => d.Ev)
                    .WithMany(p => p.Nerecords)
                    .HasForeignKey(d => d.Evid)
                    .HasConstraintName("FK_record_category");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.Nerecords)
                    .HasForeignKey(d => d.MarkId)
                    .HasConstraintName("FK_NER_Marks");

                entity.HasOne(d => d.N)
                    .WithMany(p => p.Nerecords)
                    .HasForeignKey(d => d.Nid)
                    .HasConstraintName("FK_NER_Nazim");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Nerecords)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_record_Zone");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification", "Not");

                entity.HasIndex(e => e.NotificationTypeId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");

                entity.Property(e => e.ReceiverUsersId).HasColumnName("ReceiverUsersID");

                entity.Property(e => e.SenderUserId).HasColumnName("SenderUserID");
            });

            modelBuilder.Entity<NotificationType>(entity =>
            {
                entity.ToTable("NotificationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.OfficeTypeId).HasColumnName("OfficeTypeID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TitleEn)
                    .IsRequired()
                    .HasColumnName("TitleEN")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("office_fk");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("office_fk_1");
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("OperationType", "au");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OperationTypeName).HasColumnType("character varying");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization", "look");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.ToTable("OrganizationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.organizationtype_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("IX_Identification_CandidateID")
                    .IsUnique();

                entity.HasIndex(e => e.PassportTypeId)
                    .HasName("fki_FK_Identification_DocumentType_DocumentTypeID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasColumnType("character varying");

                entity.Property(e => e.PassportTypeId).HasColumnName("PassportTypeID");

                entity.HasOne(d => d.Candidate)
                    .WithOne(p => p.Passport)
                    .HasForeignKey<Passport>(d => d.CandidateId)
                    .HasConstraintName("FK_Identification_Candidate_CandidateID");

                entity.HasOne(d => d.PassportType)
                    .WithMany(p => p.Passport)
                    .HasForeignKey(d => d.PassportTypeId)
                    .HasConstraintName("FK_pasport_pasporttype");
            });

            modelBuilder.Entity<PassportType>(entity =>
            {
                entity.ToTable("PassportType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<PerYearCpacity>(entity =>
            {
                entity.ToTable("PerYearCpacity", "HPC");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CandidatId).HasColumnName("CandidatID");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.YearId).HasColumnName("yearID");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process", "prc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

                entity.Property(e => e.Sorter).HasMaxLength(10);
            });

            modelBuilder.Entity<ProcessConnection>(entity =>
            {
                entity.ToTable("ProcessConnection", "prc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.HasOne(d => d.ConnectedToNavigation)
                    .WithMany(p => p.ProcessConnectionConnectedToNavigation)
                    .HasForeignKey(d => d.ConnectedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_ProcessConnection__FK_1");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessConnectionProcess)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_ProcessConnection__FK");
            });

            modelBuilder.Entity<ProcessTracking>(entity =>
            {
                entity.ToTable("ProcessTracking", "prc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.ReferedProcessId).HasColumnName("ReferedProcessID");

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.ToUserId).HasColumnName("ToUserID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.ProcessTracking)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_ProcessTracking__FK");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.TitleEn)
                    .IsRequired()
                    .HasColumnName("TitleEN")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ProvincesCapacity>(entity =>
            {
                entity.ToTable("ProvincesCapacity", "prf");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("fki_FK_Provinc_locationn");

                entity.HasIndex(e => e.TotalId)
                    .HasName("fki_FK_pro_total");

                entity.HasIndex(e => e.YearId)
                    .HasName("fki_FK_provinc_year");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.TotalId).HasColumnName("TotalID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.ProvincesCapacity)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Provinc_locationn");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.ProvincesCapacity)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_provinc_year");
            });

            modelBuilder.Entity<Qouta>(entity =>
            {
                entity.ToTable("Qouta", "prf");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("fki_FK_qouta_spetype");

                entity.HasIndex(e => e.YearId)
                    .HasName("fki_FK_qouta_year");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Qouta)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_qouta_spetype");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Qouta)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_qouta_year");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question", "prf");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("Rank", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.rank_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<RegistrationType>(entity =>
            {
                entity.ToTable("RegistrationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.ToTable("Relation", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Relative>(entity =>
            {
                entity.ToTable("Relative", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .IsUnique();

                entity.HasIndex(e => e.DistrictId)
                    .HasName("fki_FK_Relative_Location_DistrictID");

                entity.HasIndex(e => e.GenderId);

                entity.HasIndex(e => e.ProvincesId);

                entity.HasIndex(e => e.RelationshipId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.FullAddress).HasColumnType("character varying");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Mobile).HasColumnType("character varying");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone).HasColumnType("character varying");

                entity.Property(e => e.ProvincesId).HasColumnName("ProvincesID");

                entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

                entity.HasOne(d => d.Candidate)
                    .WithOne(p => p.Relative)
                    .HasForeignKey<Relative>(d => d.CandidateId);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.RelativeDistrict)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Relative)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Provinces)
                    .WithMany(p => p.RelativeProvinces)
                    .HasForeignKey(d => d.ProvincesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relative_Location_LocationID");

                entity.HasOne(d => d.Relationship)
                    .WithMany(p => p.Relative)
                    .HasForeignKey(d => d.RelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relative_Relationship_RelationshipID");
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("Religion", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<ReturnMoney>(entity =>
            {
                entity.ToTable("ReturnMoney", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.CurrencyId);

                entity.HasIndex(e => e.RelativeId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.RelativeId).HasColumnName("RelativeID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ReturnMoney)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.ReturnMoney)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Relative)
                    .WithMany(p => p.ReturnMoney)
                    .HasForeignKey(d => d.RelativeId);
            });

            modelBuilder.Entity<RoleScreen>(entity =>
            {
                entity.ToTable("RoleScreen", "look");

                entity.HasIndex(e => e.ScreenId);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.ToTable("Screen", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DirectoryPath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Screen)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("screen_fk");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("screen_parent_fk");
            });

            modelBuilder.Entity<ScreenDocument>(entity =>
            {
                entity.ToTable("ScreenDocument", "doc");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ScreenDocument)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("_ScreenDocument__FK");
            });

            modelBuilder.Entity<SelectQueue>(entity =>
            {
                entity.ToTable("SelectQueue", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("fki_fk_que_candidate");

                entity.HasIndex(e => e.CurrentYearsId)
                    .HasName("fki_fk_que_year");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrentYearsId).HasColumnName("CurrentYearsID");

                entity.Property(e => e.FatherName).HasColumnType("character varying");

                entity.Property(e => e.FirstName).HasColumnType("character varying");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName).HasColumnType("character varying");

                entity.Property(e => e.SelectedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.SelectQueue)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_que_candidate");
            });

            modelBuilder.Entity<SpecialEntity>(entity =>
            {
                entity.ToTable("SpecialEntity", "prf");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("fki_FK_spe_candidate");

                entity.HasIndex(e => e.OrganizationId)
                    .HasName("fki_FK_speO_spet");

                entity.HasIndex(e => e.SpecialEntityTypeId)
                    .HasName("fki_FK_Spe_Spet");

                entity.HasIndex(e => e.YearId)
                    .HasName("fki_FK_spe_year");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.DepartmentName).HasColumnType("character varying");

                entity.Property(e => e.Discription).HasColumnType("character varying");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.Refrence).HasColumnType("character varying");

                entity.Property(e => e.ShoraName).HasColumnType("character varying");

                entity.Property(e => e.SpecialEntityTypeId).HasColumnName("SpecialEntityTypeID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.SpecialEntity)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_spe_candidate");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.SpecialEntityOrganization)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_speO_spet");

                entity.HasOne(d => d.SpecialEntityType)
                    .WithMany(p => p.SpecialEntitySpecialEntityType)
                    .HasForeignKey(d => d.SpecialEntityTypeId)
                    .HasConstraintName("FK_Spe_Spet");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.SpecialEntity)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_spe_year");
            });

            modelBuilder.Entity<SpecialEntityType>(entity =>
            {
                entity.ToTable("SpecialEntityType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Sscandidate>(entity =>
            {
                entity.ToTable("SSCandidate", "SSFB");

                entity.HasIndex(e => e.CandidateId)
                    .HasName("fki_FK_SS_Candidate");

                entity.HasIndex(e => e.GenderId)
                    .HasName("fki_FK_SS_Gender");

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("fki_FK_SS_address");

                entity.HasIndex(e => e.YearId)
                    .HasName("fki_FK_SS_Year");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Sscandidate)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK_SS_Candidate");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Sscandidate)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_SS_Gender");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Sscandidate)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_SS_address");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Sscandidate)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_SS_Year");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.status_seq'::regclass)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.ToTable("StatusType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TicketDiscount>(entity =>
            {
                entity.ToTable("TicketDiscount", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<TicketInfo>(entity =>
            {
                entity.ToTable("TicketInfo", "prf");

                entity.HasIndex(e => e.AirLineId);

                entity.HasIndex(e => e.CandidateId);

                entity.HasIndex(e => e.DepartureProvincesId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirLineId).HasColumnName("AirLineID");

                entity.Property(e => e.ArrivalProvincesId).HasColumnName("ArrivalProvincesID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.DepartureProvincesId).HasColumnName("DepartureProvincesID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.YearId).HasColumnName("YearID");

                entity.HasOne(d => d.AirLine)
                    .WithMany(p => p.TicketInfo)
                    .HasForeignKey(d => d.AirLineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketInfo_AirLine_AirLineID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.TicketInfo)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.TicketInfo)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TicketOrder>(entity =>
            {
                entity.ToTable("TicketOrder", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasColumnType("character varying");
            });

            modelBuilder.Entity<VCandidate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vCandidate", "prf");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");
            });

            modelBuilder.Entity<VisaInfo>(entity =>
            {
                entity.ToTable("VisaInfo", "prf");

                entity.HasIndex(e => e.CandidateId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.VisaNo).HasColumnType("character varying");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.VisaInfo)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Wages>(entity =>
            {
                entity.ToTable("Wages", "prf");

                entity.HasIndex(e => e.EmployeeContractTypeId)
                    .HasName("fki_FK_Wages_EmployeeContractType_EmployeeContractTypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeContractTypeId).HasColumnName("EmployeeContractTypeID");

                entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

                entity.HasOne(d => d.EmployeeContractType)
                    .WithMany(p => p.Wages)
                    .HasForeignKey(d => d.EmployeeContractTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wages_EmployeeContractType_EmployeeContractTypeID");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("Year", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();
            });

            modelBuilder.HasSequence("applicationreason_seq", "look").StartsAt(11);

            modelBuilder.HasSequence("applicationtype_seq", "look").StartsAt(3);

            modelBuilder.HasSequence("bloodgroup_seq", "look").StartsAt(10);

            modelBuilder.HasSequence("categorytype_seq", "look").StartsAt(8);

            modelBuilder.HasSequence("disabletype_seq", "look").StartsAt(3);

            modelBuilder.HasSequence("documenttype_seq", "look").StartsAt(27);

            modelBuilder.HasSequence("education_seq", "look").StartsAt(5);

            modelBuilder.HasSequence("eventreason_seq", "look").StartsAt(1007);

            modelBuilder.HasSequence("gender_seq", "look").StartsAt(3);

            modelBuilder.HasSequence("heritagejob_seq", "look").StartsAt(3);

            modelBuilder.HasSequence("lawyertype_seq", "look").StartsAt(4);

            modelBuilder.HasSequence("maritalstatus_seq", "look").StartsAt(5);

            modelBuilder.HasSequence("ministryrec_seq", "look").StartsAt(4);

            modelBuilder.HasSequence("organizationtype_seq", "look").StartsAt(2);

            modelBuilder.HasSequence("paymentperiod_seq", "look").StartsAt(4);

            modelBuilder.HasSequence("processconnection_seq", "look").StartsAt(23);

            modelBuilder.HasSequence("province_seq", "look");

            modelBuilder.HasSequence("rank_seq", "look").StartsAt(106);

            modelBuilder.HasSequence("rolescreens_seq", "look").StartsAt(1207);

            modelBuilder.HasSequence("serviecetype_seq", "look").StartsAt(3);

            modelBuilder.HasSequence("status_seq", "look").StartsAt(6);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
