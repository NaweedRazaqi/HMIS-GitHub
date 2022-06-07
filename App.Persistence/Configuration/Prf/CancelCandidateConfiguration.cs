using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class CancelCandidateConfiguration : IEntityTypeConfiguration<CancelCandidate>
    {
        public void Configure(EntityTypeBuilder<CancelCandidate> entity)
        {
            entity.ToTable("CancelCandidate", "prf");

            entity.HasIndex(e => e.CandidateId)
                .HasName("fki_FK_CancelCandidate_Candidate_CandidateID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.CancelCandidate)
                .HasForeignKey(d => d.CandidateId);
        }
    }
}
