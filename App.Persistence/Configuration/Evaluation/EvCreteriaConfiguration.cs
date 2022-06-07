using App.Domain.Entity.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Evaluation
{

    public class EvCreteriaConfiguration : IEntityTypeConfiguration<EvCreteria>
    {

        public void Configure(EntityTypeBuilder<EvCreteria> entity)
        {
            entity.ToTable("EvCreteria", "NE");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.EvZoneTypeId).HasColumnName("EvZoneTypeID");

            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.HasOne(d => d.EvZoneType)
                            .WithMany()
                            .HasForeignKey(d => d.EvZoneTypeId)
                            .HasConstraintName("ٍٰEvZoneType_ID_FK");
        }


    }
}

    
