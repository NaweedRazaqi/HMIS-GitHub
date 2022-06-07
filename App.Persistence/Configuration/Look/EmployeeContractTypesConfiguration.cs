using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{
    public class EmployeeContractTypesConfiguration : IEntityTypeConfiguration<EmployeeContractTypes>
    {
        public void Configure(EntityTypeBuilder<EmployeeContractTypes> entity)
        {
            entity.ToTable("EmployeeContractTypes", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
