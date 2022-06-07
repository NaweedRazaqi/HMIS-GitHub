using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> entity)
        {
            entity.ToTable("Organization", "look");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Dari)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.ParentId).HasColumnName("ParentID");

            entity.Property(e => e.Pashto)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        }
    }
}
