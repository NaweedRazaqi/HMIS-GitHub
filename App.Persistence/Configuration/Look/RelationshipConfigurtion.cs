using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class RelationshipConfigurtion : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> entity)
        {
            entity.ToTable("Relation", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            entity.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
