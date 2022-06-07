using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class NazamSalaryConfigurtion : IEntityTypeConfiguration<NazamSalary>
    {
        public void Configure(EntityTypeBuilder<NazamSalary> entity)
        {
            entity.ToTable("NazamSalary", "prf");

            entity.HasIndex(e => e.NazamId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.NazamId).HasColumnName("NazamID");

            entity.HasOne(d => d.Nazam)
                .WithMany(p => p.NazamSalary)
                .HasForeignKey(d => d.NazamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
