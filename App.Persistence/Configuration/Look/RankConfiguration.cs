using App.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Persistence.Configuration.Look
{

    class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> entity)
        {
            entity.ToTable("Rank", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("nextval('look.rank_seq'::regclass)");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
        }
    }
}
