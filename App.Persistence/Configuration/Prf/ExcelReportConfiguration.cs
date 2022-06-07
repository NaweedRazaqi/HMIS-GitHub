using App.Domain.Entity.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class ExcelReportConfiguration : IEntityTypeConfiguration<ExecelReport>
    {
        public void Configure(EntityTypeBuilder<ExecelReport> entity)
        {
            entity.HasNoKey();

            entity.ToTable("ExecelReport", "prf");

            entity.Property(e => e.CurrentDistricts).HasMaxLength(100);

            entity.Property(e => e.CurrentProvince).HasMaxLength(100);

            entity.Property(e => e.Gender).HasMaxLength(50);

            entity.Property(e => e.GrandFatherName).HasColumnName("GrandFatherName ");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.PerminantDistricts).HasMaxLength(100);

            entity.Property(e => e.PerminantProvince).HasMaxLength(100);

            entity.Property(e => e.Religion).HasMaxLength(50);
        }
    }
}
