using App.Domain.Entity.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Views
{
    public class ViewConfiguration : IEntityTypeConfiguration<Installments>
    {
        public void Configure(EntityTypeBuilder<Installments> entity)
        {
            entity.HasNoKey();

            entity.ToTable("Installments", "prf");

            entity.Property(e => e.Destricts).HasMaxLength(100);
            entity.Property(e => e.NationalId)
                .HasColumnName("NationalID")
                .HasColumnType("character varying");

            entity.Property(e => e.Province).HasMaxLength(100);

            entity.Property(e => e.Religion).HasMaxLength(50);
        }
    }
}
