using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class NazamAssignmentConfigurtion : IEntityTypeConfiguration<NazamAssignment>
    {
        public void Configure(EntityTypeBuilder<NazamAssignment> entity)
        {
            entity.ToTable("NazamAssignment", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.NazamCandidateId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.NazamCandidateId).HasColumnName("NazamCandidateID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.NazamAssignmentCandidate)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NazamCandidate)
                .WithMany(p => p.NazamAssignmentNazamCandidate)
                .HasForeignKey(d => d.NazamCandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
