using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class HajiMahramDetailsConfiguration : IEntityTypeConfiguration<HajiMahramdetails>
    {
        public void Configure(EntityTypeBuilder<HajiMahramdetails> entity)
        {
            entity.HasNoKey();

            entity.ToTable("HajiMahramdetails", "prf");

            entity.Property(e => e.Genders).HasMaxLength(50);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Mahramid).HasColumnName("mahramid");

            entity.Property(e => e.Mahramlast).HasColumnName("mahramlast");

            entity.Property(e => e.Mahramname).HasColumnName("mahramname");

            entity.Property(e => e.Relegions).HasMaxLength(50);
        }
    }
}


