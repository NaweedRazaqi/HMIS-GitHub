using Clean.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class OrganizationTypeConfigurtion : IEntityTypeConfiguration<OrganizationType>
    {
        public void Configure(EntityTypeBuilder<OrganizationType> entity)
        {
            entity.ToTable("OrganizationType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('look.organizationtype_seq'::regclass)");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
