using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class HajjYearConfiguration : IEntityTypeConfiguration<HajjYear>
    {
        public void Configure(EntityTypeBuilder<HajjYear> entity)
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

            //entity.HasOne(d => d.Candidate)
            //    .WithMany(p => p.HajjYears)
            //    .HasForeignKey(d => d.CandidateId);

            entity.HasOne(d => d.Provinces)
                .WithMany(p => p.HajjYear)
                .HasForeignKey(d => d.ProvincesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HajjYear_Location_LocationID");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.HajjYear)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
