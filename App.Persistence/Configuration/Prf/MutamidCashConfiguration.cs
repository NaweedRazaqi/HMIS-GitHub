using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class MutamidCashConfiguration : IEntityTypeConfiguration<MutamidCashes>
    {
        public void Configure(EntityTypeBuilder<MutamidCashes> entity)
        {
            entity.ToTable("MutamidCashes", "prf");

            entity.HasIndex(e => e.CurrencyId)
                .HasName("IX_mutamidCashes_CurrencyID");

            entity.HasIndex(e => e.ExpenseCenterId)
                .HasName("IX_mutamidCashes_ExpenseCenterID");

            entity.HasIndex(e => e.MutamidId)
                .HasName("IX_mutamidCashes_MutamidID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('prf.\"mutamidCashes_ID_seq\"'::regclass)");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.ExpenseCenterId).HasColumnName("ExpenseCenterID");

            entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.MutamidCashes)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ExpenseCenter)
                .WithMany(p => p.MutamidCashes)
                .HasForeignKey(d => d.ExpenseCenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MutamidCashes_ExpenseCenter_ExpenseCenterID");

            entity.HasOne(d => d.Mutamid)
                .WithMany(p => p.MutamidCashes)
                .HasForeignKey(d => d.MutamidId)
                .HasConstraintName("FK_mutamidCashes_mutamids_MutamidID");
        }
    }
}
