using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class VisaInfoConfiguration : IEntityTypeConfiguration<VisaInfo>
    {
        public void Configure(EntityTypeBuilder<VisaInfo> entity)
        {
            entity.ToTable("VisaInfo", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.VisaInfo)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VisaType)
                .WithMany(p => p.VisaInfo)
                .HasForeignKey(d => d.VisaTypeId)
                .HasConstraintName("VisaInfo_VisaTypeId_fkey");
        }
    }
}
