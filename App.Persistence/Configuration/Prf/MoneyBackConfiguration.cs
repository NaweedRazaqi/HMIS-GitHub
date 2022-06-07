using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class MoneyBackConfiguration : IEntityTypeConfiguration<MoneyBack>
    {
        public void Configure(EntityTypeBuilder<MoneyBack> entity)
        {
            entity.ToTable("MoneyBack", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.CurrencyId);

            entity.HasIndex(e => e.HajjYearId);

            entity.HasIndex(e => e.RelativeId);

            entity.HasIndex(e => e.YearId)
                .HasName("fki_FK_MoneyBack_Year_YearID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CheckedBy).HasColumnName("checkedBy");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.HajjYearId).HasColumnName("HajjYearID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.NumberMaktoobBank).HasColumnName("NumberMaktoob_bank");

            entity.Property(e => e.RelativeId).HasColumnName("RelativeID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.MoneyBack)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.MoneyBack)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HajjYear)
                .WithMany(p => p.MoneyBack)
                .HasForeignKey(d => d.HajjYearId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Relative)
                .WithMany(p => p.MoneyBack)
                .HasForeignKey(d => d.RelativeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Year)
                .WithMany(p => p.MoneyBack)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
