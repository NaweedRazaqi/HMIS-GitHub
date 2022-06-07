using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class CandidateStatusConfiguration : IEntityTypeConfiguration<CandidateStatus>
    {
        public void Configure(EntityTypeBuilder<CandidateStatus> entity)
        {
            entity.ToTable("CandidateStatus", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.CprovincesId);

            entity.HasIndex(e => e.StatusTypeId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CprovincesId).HasColumnName("CProvincesID");

            entity.Property(e => e.StatusTypeId).HasColumnName("StatusTypeID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.CandidateStatus)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cprovinces)
                .WithMany(p => p.CandidateStatus)
                .HasForeignKey(d => d.CprovincesId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StatusType)
                .WithMany(p => p.CandidateStatus)
                .HasForeignKey(d => d.StatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
