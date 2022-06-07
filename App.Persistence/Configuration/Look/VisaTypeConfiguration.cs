using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{

    class VisaTypeConfiguration : IEntityTypeConfiguration<VisaType>
    {
        public void Configure(EntityTypeBuilder<VisaType> entity)
        {
            entity.ToTable("VisaType", "look");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name).HasColumnType("character varying");
        }
    }
}
