using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class InstallmentTypeConfiguration : IEntityTypeConfiguration<InstallmentType>
    {
        public void Configure(EntityTypeBuilder<InstallmentType> entity)
        {
            entity.ToTable("InstallmentType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
