using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class StudyFieldConfiguration : IEntityTypeConfiguration<FieldofStudy>
    {
        public void Configure(EntityTypeBuilder<FieldofStudy> entity)
        {
            entity.ToTable("FieldofStudy", "look");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("text")
                .HasMaxLength(100);
        }
    }
}
