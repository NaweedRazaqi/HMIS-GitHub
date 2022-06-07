using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class MutamidAccountConfiguration : IEntityTypeConfiguration<MutamidAccounts>
    {
        public void Configure(EntityTypeBuilder<MutamidAccounts> entity)
        {
            entity.ToTable("MutamidAccounts", "prf");

            entity.HasIndex(e => e.CurrencyId)
                .HasName("IX_mutamidAccounts_CurrencyID");

            entity.HasIndex(e => e.MutamidId)
                .HasName("IX_mutamidAccounts_MutamidID");

            entity.HasIndex(e => e.YearId)
                .HasName("IX_mutamidAccounts_YearID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('prf.\"mutamidAccounts_ID_seq\"'::regclass)");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            //entity.HasOne(d => d.Currency)
            //    .WithMany(p => p.MutamidAccounts)
            //    .HasForeignKey(d => d.CurrencyId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_mutamidAccounts_Currency_CurrencyID");

            entity.HasOne(d => d.Mutamid)
                .WithMany(p => p.MutamidAccounts)
                .HasForeignKey(d => d.MutamidId)
                .HasConstraintName("FK_mutamidAccounts_mutamids_MutamidID");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.MutamidAccounts)
                .HasForeignKey(d => d.YearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mutamidAccounts_Year_YearID");
        }
    }
}
