using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class MosqueConfiguration : IEntityTypeConfiguration<Mosque>
    {
        public void Configure(EntityTypeBuilder<Mosque> entity)
        {
            entity.ToTable("Mosque", "prf");

            entity.HasIndex(e => e.DistrictId)
                .HasName("fki_FK_Mosque_Location_DistrictID");

            entity.HasIndex(e => e.ProvinceId)
                .HasName("fki_FK_Mosque_Location_ProvinceID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

            entity.HasOne(d => d.District)
                .WithMany(p => p.MosqueDistrict)
                .HasForeignKey(d => d.DistrictId);

            entity.HasOne(d => d.Province)
                .WithMany(p => p.MosqueProvince)
                .HasForeignKey(d => d.ProvinceId);
        }
    }
}
