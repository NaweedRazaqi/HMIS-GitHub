using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class TicketInfoConfiguration : IEntityTypeConfiguration<TicketInfo>
    {
        public void Configure(EntityTypeBuilder<TicketInfo> entity)
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
        }
    }
}
