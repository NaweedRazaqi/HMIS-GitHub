using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bank> entity)
        {
            entity.ToTable("Bank", "look");
            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
