using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Look
{
    class BloodGroupConfiguration : IEntityTypeConfiguration<BloodGroup>
    {
        public void Configure(EntityTypeBuilder<BloodGroup> entity)
        {
            entity.ToTable("BloodGroup", "look");
            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('look.bloodgroup_seq'::regclass)");
            entity.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
