using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class HajYearlyConfiguration : IEntityTypeConfiguration<HajyearlyCapacity>
    {
        public void Configure(EntityTypeBuilder<HajyearlyCapacity> entity)
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
        }
    }
}
