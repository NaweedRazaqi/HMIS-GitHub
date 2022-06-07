using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{

    class EmaraTypeConfiguration : IEntityTypeConfiguration<EmaraType>
    {
        public void Configure(EntityTypeBuilder<EmaraType> entity)
        {
            entity.ToTable("EmaraType", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Name).HasColumnType("character varying");
        }

      
        }
    }

      
   
