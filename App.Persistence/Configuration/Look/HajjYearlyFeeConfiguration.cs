using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{

    class HajjYearlyFeeConfiguration : IEntityTypeConfiguration<HajjYearlyFee>
    {



        public void Configure(EntityTypeBuilder<HajjYearlyFee> entity)
        {
            entity.ToTable("HajjYearlyFee", "look");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Fee).HasColumnType("numeric");

            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.Year)
                            .WithMany()
                            .HasForeignKey(d => d.YearId)
                            .HasConstraintName("YearID_FK");
        }
    }
}
