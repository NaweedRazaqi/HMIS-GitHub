using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
   public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ExamResult> entity)
        {
            entity.ToTable("ExamResult", "prf");

            entity.Property(e => e.Id).HasColumnName("ID");
        }
    }
}
