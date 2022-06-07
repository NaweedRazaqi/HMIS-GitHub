using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    

    public class NazemExperienceConfiguration : IEntityTypeConfiguration<NazemExperience>
    {
        public void Configure(EntityTypeBuilder<NazemExperience> entity)
        {
            entity.ToTable("NazemExperience", "prf");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.NazemExperiences)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Candidate_ID_FK");

            entity.HasOne(d => d.Year)
                .WithMany()
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("Year_ID_FK");
        }
    }
}
