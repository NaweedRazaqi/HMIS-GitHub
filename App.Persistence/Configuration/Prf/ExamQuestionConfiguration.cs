using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> entity)
        {
            entity.ToTable("ExamQuestion", "prf");

            entity.HasIndex(e => e.ExamId);

            entity.HasIndex(e => e.QuestionId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ExamId).HasColumnName("ExamID");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

            entity.HasOne(d => d.Exam)
                .WithMany(p => p.ExamQuestion)
                .HasForeignKey(d => d.ExamId);

            entity.HasOne(d => d.Question)
                .WithMany(p => p.ExamQuestion)
                .HasForeignKey(d => d.QuestionId);
        }
    }
}
