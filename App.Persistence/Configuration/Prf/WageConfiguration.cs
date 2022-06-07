using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class WageConfiguration : IEntityTypeConfiguration<Wages>
    {
        public void Configure(EntityTypeBuilder<Wages> entity)
        {
            entity.ToTable("Wages", "prf");

            entity.HasIndex(e => e.EmployeeContractTypeId)
                .HasName("fki_FK_Wages_EmployeeContractType_EmployeeContractTypeID");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('prf.\"wages_ID_seq\"'::regclass)");

            entity.Property(e => e.EmployeeContractTypeId).HasColumnName("EmployeeContractTypeID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.HasOne(d => d.EmployeeContractType)
                .WithMany(p => p.Wages)
                .HasForeignKey(d => d.EmployeeContractTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wages_EmployeeContractType_EmployeeContractTypeID");
        }
    }
}
