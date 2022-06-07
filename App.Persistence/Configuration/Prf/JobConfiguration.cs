using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> entity)
        {

            entity.ToTable("Job", "prf");

            entity.HasIndex(e => e.CandidateId)
                .HasName("fki_FK_Job_Candidate_CandidateID");

            entity.HasIndex(e => e.JobTilteId)
                .HasName("fki_FK_job_jobtitle");

            entity.HasIndex(e => e.OrganizationId)
                .HasName("fki_FK_job_org");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

            entity.Property(e => e.JobTilteId).HasColumnName("JobTilteID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

            entity.Property(e => e.RankId).HasColumnName("RankID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.Job)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.District)
                .WithMany()
                .HasForeignKey(d => d.DistrictId)
                .HasConstraintName("FK-DisctrictID");

            entity.HasOne(d => d.JobTilte)
                .WithMany(p => p.JobJobTilte)
                .HasForeignKey(d => d.JobTilteId)
                .HasConstraintName("FK_job_jobtitle");

            entity.HasOne(d => d.Organization)
                .WithMany(p => p.Jobs)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_job_org");

            entity.HasOne(d => d.Province)
                .WithMany()
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("Fk-ProvinceID");

            entity.HasOne(d => d.Rank)
                .WithMany(p => p.Job)
                .HasForeignKey(d => d.RankId)
                .HasConstraintName("FK_Rank_ID");
        }
    }
}
