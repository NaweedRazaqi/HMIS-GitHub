using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> entity)
        {
            entity.ToTable("Education", "prf");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.Property(e => e.DegreeId).HasColumnName("DegreeID");

            entity.Property(e => e.FieldofstudyId).HasColumnName("FieldofstudyID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.StudyTypeId).HasColumnName("StudyTypeID");

            entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.Education)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("fki_FK_Ed_candidate");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.Education)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_ED_Location");

            entity.HasOne(d => d.Degree)
                .WithMany(p => p.Education)
                .HasForeignKey(d => d.DegreeId)
                .HasConstraintName("FK_ed_deg");

            entity.HasOne(d => d.Fieldofstudy)
                .WithMany(p => p.Education)
                .HasForeignKey(d => d.FieldofstudyId)
                .HasConstraintName("FK_ED_Field");

            entity.HasOne(d => d.University)
                .WithMany(p => p.Education)
                .HasForeignKey(d => d.UniversityId)
                .HasConstraintName("FK_University");
        }
    }
}
