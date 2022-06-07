using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> entity)
        {
            entity.ToTable("Exam", "prf");

            entity.HasIndex(e => e.CommiteeId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CommiteeId).HasColumnName("CommiteeID");

            entity.HasOne(d => d.Commitee)
                .WithMany(p => p.Exam)
                .HasForeignKey(d => d.CommiteeId);
        }
    }
}
