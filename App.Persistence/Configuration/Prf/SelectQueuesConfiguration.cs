using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class SelectQueuesConfiguration : IEntityTypeConfiguration<SelectQueue>
    {
        public void Configure(EntityTypeBuilder<SelectQueue> entity)
        {
            entity.ToTable("SelectQueue", "prf");

            entity.HasIndex(e => e.CandidateId)
                .HasName("fki_fk_que_candidate");

            entity.HasIndex(e => e.CurrentYearsId)
                .HasName("fki_fk_que_year");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

            entity.Property(e => e.CurrentYearsId).HasColumnName("CurrentYearsID");

            entity.Property(e => e.FatherName).HasColumnType("character varying");

            entity.Property(e => e.FirstName).HasColumnType("character varying");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");

            entity.Property(e => e.LastName).HasColumnType("character varying");

            entity.Property(e => e.SelectedOn).HasColumnType("timestamp with time zone");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.SelectQueue)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_que_candidate");
        }
    }
}