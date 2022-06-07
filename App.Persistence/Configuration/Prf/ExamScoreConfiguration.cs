using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class ExamScoreConfiguration : IEntityTypeConfiguration<ExamScore>
    {
        public void Configure(EntityTypeBuilder<ExamScore> entity)
        {
            entity.ToTable("ExamScore", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.ExamResultId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.ExamResultId).HasColumnName("ExamResultID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.ExamScore)
                .HasForeignKey(d => d.CandidateId);

            entity.HasOne(d => d.ExamResult)
                .WithMany(p => p.ExamScore)
                .HasForeignKey(d => d.ExamResultId);
        }
    }
}
