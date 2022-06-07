using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    class AttendenceConfiguration : IEntityTypeConfiguration<Attendence>
    {
        public void Configure(EntityTypeBuilder<Attendence> entity)
        {
            entity.ToTable("Attendence", "prf");

            entity.HasIndex(e => e.AttendenceTypeId);

            entity.HasIndex(e => e.NazamId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.AttendenceTypeId).HasColumnName("AttendenceTypeID");

            entity.Property(e => e.NazamId).HasColumnName("NazamID");

            entity.HasOne(d => d.AttendenceType)
                .WithMany(p => p.Attendence)
                .HasForeignKey(d => d.AttendenceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendence_AttendenceType_AttendenceTypeID");

            entity.HasOne(d => d.Nazam)
                .WithMany(p => p.Attendence)
                .HasForeignKey(d => d.NazamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
