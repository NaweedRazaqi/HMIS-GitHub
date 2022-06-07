using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    class ReturnMoneyConfiguration : IEntityTypeConfiguration<ReturnMoney>
    {
        public void Configure(EntityTypeBuilder<ReturnMoney> entity)
        {
            entity.ToTable("ReturnMoney", "prf");

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.CurrencyId);

            entity.HasIndex(e => e.RelativeId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.RelativeId).HasColumnName("RelativeID");

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.ReturnMoney)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.ReturnMoney)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Relative)
                .WithMany(p => p.ReturnMoney)
                .HasForeignKey(d => d.RelativeId);
        }
    }
}
