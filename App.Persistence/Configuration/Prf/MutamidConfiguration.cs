using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Entity.prf;

namespace App.Persistence.Configuration.Prf
{
    public class MutamidConfiguration : IEntityTypeConfiguration<Mutamids>
    {
        public void Configure(EntityTypeBuilder<Mutamids> entity)
        {
            entity.ToTable("Mutamids", "prf");

            entity.HasIndex(e => e.DistrictsId)
                .HasName("IX_mutamids_DistrictsID");

            entity.HasIndex(e => e.ProvincesId)
                .HasName("IX_mutamids_ProvincesID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('prf.\"mutamids_ID_seq\"'::regclass)");

            entity.Property(e => e.DistrictsId).HasColumnName("DistrictsID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.ProvincesId).HasColumnName("ProvincesID");

            entity.HasOne(d => d.Districts)
                .WithMany(p => p.MutamidsDistricts)
                .HasForeignKey(d => d.DistrictsId);

            entity.HasOne(d => d.Provinces)
                .WithMany(p => p.MutamidsProvinces)
                .HasForeignKey(d => d.ProvincesId);
        }
    }
}
