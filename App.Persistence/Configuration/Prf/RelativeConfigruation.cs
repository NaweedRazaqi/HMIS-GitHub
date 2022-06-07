using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class RelativeConfigruation : IEntityTypeConfiguration<Relative>
    {
        public void Configure(EntityTypeBuilder<Relative> entity)
        {
            entity.ToTable("Relative", "prf");

            entity.HasIndex(e => e.CandidateId)
                .IsUnique();

            entity.HasIndex(e => e.DistrictId)
                .HasName("fki_FK_Relative_Location_DistrictID");

            entity.HasIndex(e => e.DocumentTypeId)
              .HasName("fki_FK_Identification_DocumentType_DocumentTypeID");

            entity.HasIndex(e => e.GenderId);

            entity.HasIndex(e => e.ProvincesId);

            entity.HasIndex(e => e.RelationshipId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");

            entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.NationalId)
               .HasColumnName("NationalID")
               .HasColumnType("character varying");

            entity.Property(e => e.ProvincesId).HasColumnName("ProvincesID");

            entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

            entity.HasOne(d => d.Candidate)
                .WithOne(p => p.Relative)
                .HasForeignKey<Relative>(d => d.CandidateId);

            entity.HasOne(d => d.District)
                .WithMany(p => p.RelativeDistrict)
                .HasForeignKey(d => d.DistrictId);

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
        }
    }
}
