using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class SpecialEntityTypeConfiguration : IEntityTypeConfiguration<SpecialEntityType>
    {
        public void Configure(EntityTypeBuilder<SpecialEntityType> entity)
        {
            entity.ToTable("SpecialEntityType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.ParentId).HasColumnName("ParentID");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        }
    }
}
