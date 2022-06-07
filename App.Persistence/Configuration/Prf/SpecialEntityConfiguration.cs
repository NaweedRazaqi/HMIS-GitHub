using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    class SpecialEntityConfiguration : IEntityTypeConfiguration<SpecialEntity>
    {
        public void Configure(EntityTypeBuilder<SpecialEntity> entity)
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
        }
    }
}
