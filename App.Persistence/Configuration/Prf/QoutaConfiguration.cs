using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class QoutaConfiguration : IEntityTypeConfiguration<Qouta>
    {
        public void Configure(EntityTypeBuilder<Qouta> entity)
        {
            entity.ToTable("Qouta", "prf");

            entity.HasIndex(e => e.OrganizationId)
                .HasName("fki_FK_qouta_spetype");

            entity.HasIndex(e => e.YearId)
                .HasName("fki_FK_qouta_year");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Organization)
                .WithMany(p => p.Qouta)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_qouta_spetype");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.Qouta)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK_qouta_year");
        }
    }
}
