using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    class CommiteeTypeConfiguration : IEntityTypeConfiguration<CommiteeType>
    {
        public void Configure(EntityTypeBuilder<CommiteeType> entity)
        {
            entity.ToTable("CommiteeType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
