using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class ApportiomentConfiguration : IEntityTypeConfiguration<Apportioment>
    {
        public void Configure(EntityTypeBuilder<Apportioment> entity)
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
        }
    }
}
