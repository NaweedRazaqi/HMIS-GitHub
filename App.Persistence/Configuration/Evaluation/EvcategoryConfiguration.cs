using App.Domain.Entity.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Evaluation
{
    public class EvcategoryConfiguration : IEntityTypeConfiguration<Evcategory>
    {
        public void Configure(EntityTypeBuilder<Evcategory> entity)
        {
            entity.ToTable("EVCategory", "NE");

            entity.HasIndex(e => e.ZoneId)
                .HasName("fki_FK_categor_Zone");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

            entity.HasOne(d => d.Zone)
                .WithMany(p => p.Evcategory)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("FK_categor_Zone");
        }
    }
}
