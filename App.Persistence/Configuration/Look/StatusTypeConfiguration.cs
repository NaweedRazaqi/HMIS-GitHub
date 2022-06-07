using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
    {
        public void Configure(EntityTypeBuilder<StatusType> entity)
        {
            entity.ToTable("StatusType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
