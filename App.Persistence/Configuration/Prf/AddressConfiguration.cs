using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address", "prf");

            entity.HasIndex(e => e.CandidateId)
                .IsUnique();

            entity.HasIndex(e => e.CdistrictId)
                .HasName("fki_FK_Address_Location_CDistrictID");

            entity.HasIndex(e => e.CprovinceId)
                .HasName("fki_FK_Address_Location_LocationID");

            entity.HasIndex(e => e.PdistrictId)
                .HasName("fki_FK_Address_Location_PDistrictID");

            entity.HasIndex(e => e.PprovinceId)
                .HasName("fki_FK_Address_Location_PProvinceID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

            entity.Property(e => e.CdistrictId).HasColumnName("CDistrictID");

            entity.Property(e => e.CfullAdd).HasColumnName("CFullAdd");

            entity.Property(e => e.CprovinceId).HasColumnName("CProvinceID");

            entity.Property(e => e.Mobile).HasColumnType("character varying");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnType("character varying");

            entity.Property(e => e.PdistrictId).HasColumnName("PDistrictID");

            entity.Property(e => e.PfullAdd).HasColumnName("PFullAdd");

            entity.Property(e => e.Phone).HasColumnType("character varying");

            entity.Property(e => e.PprovinceId).HasColumnName("PProvinceID");

            entity.HasOne(d => d.Candidate)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.CandidateId);

            entity.HasOne(d => d.Cdistrict)
                .WithMany(p => p.AddressCdistrict)
                .HasForeignKey(d => d.CdistrictId);

            entity.HasOne(d => d.Cprovince)
                .WithMany(p => p.AddressCprovince)
                .HasForeignKey(d => d.CprovinceId);

            entity.HasOne(d => d.Pdistrict)
                .WithMany(p => p.AddressPdistrict)
                .HasForeignKey(d => d.PdistrictId);

            entity.HasOne(d => d.Pprovince)
                .WithMany(p => p.AddressPprovince)
                .HasForeignKey(d => d.PprovinceId);
        }
    }
}
