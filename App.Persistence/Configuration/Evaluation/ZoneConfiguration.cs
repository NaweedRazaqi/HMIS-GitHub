using App.Domain.Entity.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Evaluation
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Evzone>
    {
        public void Configure(EntityTypeBuilder<Evzone> entity)
        {
            entity.ToTable("EVZone", "NE");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name).HasColumnType("character varying");
        }
    }
}
