using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
  public  class CandidateTypeConfiguration : IEntityTypeConfiguration<CandidateTypes>
    {
        public void Configure(EntityTypeBuilder<CandidateTypes> entity)
        {
            entity.ToTable("CandidateTypes", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
