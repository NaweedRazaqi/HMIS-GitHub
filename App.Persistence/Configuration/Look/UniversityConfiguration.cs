using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{



    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {


        public void Configure(EntityTypeBuilder<University> entity)
        {
            entity.ToTable("University", "look");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name).HasColumnType("character varying");
        }
    }
}
