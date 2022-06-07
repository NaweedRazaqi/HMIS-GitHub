using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class AttendenceTypeConfiguration : IEntityTypeConfiguration<AttendenceType>
    {
        public void Configure(EntityTypeBuilder<AttendenceType> entity)
        {
            entity.ToTable("AttendenceType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

        }
    }
}
