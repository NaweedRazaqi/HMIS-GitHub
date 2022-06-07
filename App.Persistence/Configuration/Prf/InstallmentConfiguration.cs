using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> entity)
        {
            entity.ToTable("Installment", "prf");

            entity.HasIndex(e => e.BankId);

            entity.HasIndex(e => e.CandidateId);

            entity.HasIndex(e => e.CurrencyId);

            entity.HasIndex(e => e.DiscountId)
                .HasName("fki_Fk_amountdiscount_disc");

            entity.HasIndex(e => e.InstallmentTypeId);

            entity.HasIndex(e => e.OrderId)
                .HasName("fki_FK_order_orders");

            entity.HasIndex(e => e.OrdererId)
                .HasName("fki_FK_whosorder_orderer");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.BankId).HasColumnName("BankID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

            entity.Property(e => e.InstallmentTypeId).HasColumnName("InstallmentTypeID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.OrdererId).HasColumnName("OrdererID");

            entity.HasOne(d => d.Bank)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Candidate)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.CandidateId);

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Discount)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("Fk_amountdiscount_disc");

            entity.HasOne(d => d.InstallmentType)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.InstallmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_order_orders");

            entity.HasOne(d => d.Orderer)
                .WithMany(p => p.Installment)
                .HasForeignKey(d => d.OrdererId)
                .HasConstraintName("FK_whosorder_orderer");
        }
    }
}
