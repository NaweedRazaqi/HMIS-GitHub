using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class ProvincesCapacityConfiguration : IEntityTypeConfiguration<ProvincesCapacity>
    {
        public void Configure(EntityTypeBuilder<ProvincesCapacity> entity)
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
            entity.Property(e => e.CandidateTypeId).HasColumnName("CandidateTypeID");

            entity.HasOne(d => d.Province)
                .WithMany(p => p.ProvincesCapacity)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Provinc_locationn");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.ProvincesCapacity)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_provinc_year");

            entity.HasOne(d => d.CandidateType)
                 .WithMany(p => p.ProvincesCapacities)
                 .HasForeignKey(d => d.CandidateTypeId)
                 .HasConstraintName("Candidate_FK_Type_ID");
        }
    }
}
