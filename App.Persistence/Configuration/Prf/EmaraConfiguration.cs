using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class EmaraConfiguration : IEntityTypeConfiguration<Emara>
    {
        public void Configure(EntityTypeBuilder<Emara> entity)
        {
            entity.ToTable("Emara", "prf");

            entity.HasIndex(e => e.LocationId);

            entity.HasIndex(e => e.YearId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.EmaraTypeNavigation)
                .WithMany(p => p.Emara)
                .HasForeignKey(d => d.EmaraType)
                .HasConstraintName("EmaraTypeID");

            entity.HasOne(d => d.EmaraZoneNavigation)
                .WithMany(p => p.Emara)
                .HasForeignKey(d => d.EmaraZone)
                .HasConstraintName("FK_EmaraZone_ID");

            entity.HasOne(d => d.Location)
                .WithMany(p => p.Emara)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Year)
                .WithMany(p => p.Emara)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
