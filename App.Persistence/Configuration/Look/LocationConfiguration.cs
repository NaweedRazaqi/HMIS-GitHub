using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.ToTable("Location", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsFixedLength();

            entity.Property(e => e.Dari)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.Property(e => e.ParentId).HasColumnName("ParentID");

            entity.Property(e => e.Path).HasMaxLength(400);

            entity.Property(e => e.PathDari).HasMaxLength(400);

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        }
    }
}