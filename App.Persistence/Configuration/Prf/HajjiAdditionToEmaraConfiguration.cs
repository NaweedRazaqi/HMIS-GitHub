using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{

    class HajjiAdditionToEmaraConfiguration : IEntityTypeConfiguration<HajjiAdditionToEmara>
    {
        

        public void Configure(EntityTypeBuilder<HajjiAdditionToEmara> entity)
        {

            entity.ToTable("HajjiAdditionToEmara", "prf");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.EmaraId).HasColumnName("EmaraID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.HajjiAdditionToEmaras)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CandidateID");

            entity.HasOne(d => d.Emara)
                .WithMany(p => p.HajjiAdditionToEmara)
                .HasForeignKey(d => d.EmaraId)
                .HasConstraintName("EmaraID");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.HajjiAdditionToEmaras)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emara_Year_YearID");
        }
    }
}