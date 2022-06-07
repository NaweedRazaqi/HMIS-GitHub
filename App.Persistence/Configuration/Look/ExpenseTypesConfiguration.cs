using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class ExpenseTypesConfiguration : IEntityTypeConfiguration<ExpenseTypes>
    {
        public void Configure(EntityTypeBuilder<ExpenseTypes> entity)
        {
            entity.ToTable("ExpenseTypes", "look");
            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
