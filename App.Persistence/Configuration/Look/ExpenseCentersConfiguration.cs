using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class ExpenseCentersConfiguration : IEntityTypeConfiguration<ExpenseCenters>
    {
        public void Configure(EntityTypeBuilder<ExpenseCenters> entity)
        {
            entity.ToTable("ExpenseCenters", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
