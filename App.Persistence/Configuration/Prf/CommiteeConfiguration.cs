using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace App.Persistence.Configuration.Prf
{
    class CommiteeConfiguration : IEntityTypeConfiguration<Commitee>
    {
        public void Configure(EntityTypeBuilder<Commitee> entity)
        {
            entity.ToTable("Commitee", "prf");

            entity.HasIndex(e => e.CommiteeTypeId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CommiteeTypeId).HasColumnName("CommiteeTypeID");

            entity.HasOne(d => d.CommiteeType)
                .WithMany(p => p.Commitee)
                .HasForeignKey(d => d.CommiteeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
