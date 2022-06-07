using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.look;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class DailyExpenseConfiguration : IEntityTypeConfiguration<DailyExpense>
    {
        public void Configure(EntityTypeBuilder<DailyExpense> entity)
        {
            entity.ToTable("DailyExpense", "prf");

            entity.HasIndex(e => e.CurrencyId);

            entity.HasIndex(e => e.ExpenseTypeId);

            entity.HasIndex(e => e.MutamidId);

            entity.HasIndex(e => e.YearId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ConvertedCurrecyId).HasColumnName("ConvertedCurrecyID");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

            entity.Property(e => e.ExpenseTypeId).HasColumnName("ExpenseTypeID");

            entity.Property(e => e.M7date).HasColumnName("M7Date");

            entity.Property(e => e.M7number).HasColumnName("M7Number");

            entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.DailyExpense)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ExpenseType)
                .WithMany(p => p.DailyExpense)
                .HasForeignKey(d => d.ExpenseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyExpense_ExpenseType_ExpenseTypeID");

            entity.HasOne(d => d.Mutamid)
                .WithMany(p => p.DailyExpense)
                .HasForeignKey(d => d.MutamidId)
                .HasConstraintName("FK_DailyExpense_mutamids_MutamidID");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.DailyExpense)
                .HasForeignKey(d => d.YearId);
        }
    }
}
