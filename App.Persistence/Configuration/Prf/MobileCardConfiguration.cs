using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class MobileCardConfiguration : IEntityTypeConfiguration<MobileCards>
    {
        public void Configure(EntityTypeBuilder<MobileCards> entity)
        {
            entity.ToTable("MobileCards", "prf");

            entity.HasIndex(e => e.MutamidId)
                .HasName("IX_mobileCards_MutamidID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('prf.\"mobileCards_ID_seq\"'::regclass)");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.MutamidId).HasColumnName("MutamidID");

            entity.Property(e => e.SpentFor).HasColumnType("character varying");

            entity.HasOne(d => d.Mutamid)
                .WithMany(p => p.MobileCards)
                .HasForeignKey(d => d.MutamidId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_mobileCards_mutamids_MutamidID");
        }
    }
}
