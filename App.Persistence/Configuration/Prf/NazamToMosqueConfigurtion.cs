using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class NazamToMosqueConfigurtion : IEntityTypeConfiguration<NazamToMosque>
    {
        public void Configure(EntityTypeBuilder<NazamToMosque> entity)
        {
            entity.ToTable("NazamToMosque", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.MosqueId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.MosqueId).HasColumnName("MosqueID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.NazamToMosque)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Location)
                .WithMany()
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Location_ID");

            entity.HasOne(d => d.Mosque)
                .WithMany(p => p.NazamToMosque)
                .HasForeignKey(d => d.MosqueId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
