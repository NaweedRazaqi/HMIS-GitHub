using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> entity)
        {
            entity.ToTable("Contract", "prf");

            entity.HasIndex(e => e.ExpenseCenterId);

            entity.HasIndex(e => e.LocationId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ExpenseCenterId).HasColumnName("ExpenseCenterID");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.ExpenseCenter)
                .WithMany(p => p.Contract)
                .HasForeignKey(d => d.ExpenseCenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_ExpenseCenter_ExpenseCenterID");

            entity.HasOne(d => d.Location)
                .WithMany(p => p.Contract)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
