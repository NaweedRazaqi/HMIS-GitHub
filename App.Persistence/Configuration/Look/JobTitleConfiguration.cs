using App.Domain.Entity.look;
using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> entity)
        {
            entity.ToTable("JobTitle", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Code).HasColumnType("character varying");

            entity.Property(e => e.Dari).HasColumnType("character varying");

            entity.Property(e => e.ParentId).HasColumnName("ParentID");

            entity.Property(e => e.Title).HasColumnType("character varying");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        }
    }
}
