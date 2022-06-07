using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class HajiStatusConfiguration : IEntityTypeConfiguration<HajiStatus>
    {
        public void Configure(EntityTypeBuilder<HajiStatus> entity)
        {
            entity.ToTable("HajiStatus", "look");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name).HasColumnType("character varying");
        }
    }
}
