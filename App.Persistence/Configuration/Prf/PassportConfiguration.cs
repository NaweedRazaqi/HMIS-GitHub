using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> entity)
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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pasport_pasporttype");
        }
    }
}
