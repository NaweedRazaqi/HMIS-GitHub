using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Persistence.Configuration.Prf
{
    class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> entity)
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

            entity.Property(e => e.CreatedOn).HasColumnName("CreatedOn");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");

            entity.Property(e => e.HajiStatusId).HasColumnName("HajiStatusID");

            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

            entity.Property(e => e.MahramId).HasColumnName("MahramID");

            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedOn");

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
        }
    }
}
