using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Prf
{
    public class CandidateSelectionConfiguration : IEntityTypeConfiguration<HajjiSelection>
    {
        public void Configure(EntityTypeBuilder<HajjiSelection> entity)
        {
            entity.HasNoKey();

            entity.ToTable("HajjiSelection", "prf");

            entity.Property(e => e.Gender).HasMaxLength(50);

            entity.Property(e => e.Hajjid).HasColumnName("HAJJID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Religion).HasMaxLength(50);

            entity.Property(e => e.YearId).HasColumnName("YearID");
        }
    }
}
