
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class ContractInstallmentConfiguration : IEntityTypeConfiguration<ContractInstallment>
    {
        public void Configure(EntityTypeBuilder<ContractInstallment> entity)
        {
            entity.ToTable("ContractInstallment", "prf");

            entity.HasIndex(e => e.ContractId);

            entity.HasIndex(e => e.CurrencyId);

            entity.HasIndex(e => e.YearId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Contract)
                .WithMany(p => p.ContractInstallment)
                .HasForeignKey(d => d.ContractId);

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.ContractInstallment)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Year)
                .WithMany(p => p.ContractInstallment)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
