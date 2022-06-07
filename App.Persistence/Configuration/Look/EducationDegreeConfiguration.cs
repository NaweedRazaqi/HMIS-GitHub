using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class EducationDegreeConfiguration : IEntityTypeConfiguration<EducationDegree>
    {
        public void Configure(EntityTypeBuilder<EducationDegree> entity)
        {
            entity.ToTable("EducationDegree", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('look.education_seq'::regclass)");

            entity.Property(e => e.Name).HasMaxLength(200);
        }
    }
}
