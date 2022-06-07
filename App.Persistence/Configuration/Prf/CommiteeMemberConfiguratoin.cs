using App.Domain.Entity.prf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace App.Persistence.Configuration.Prf
{
    class CommiteeMemberConfiguratoin : IEntityTypeConfiguration<CommiteeMember>
    {
        public void Configure(EntityTypeBuilder<CommiteeMember> entity)
        {
            entity.ToTable("CommiteeMember", "prf");

            entity.HasIndex(e => e.CommiteeId);

            entity.HasIndex(e => e.GenderId);

            entity.HasIndex(e => e.OrganizationId);

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CommiteeId).HasColumnName("CommiteeID");

            entity.Property(e => e.GenderId).HasColumnName("GenderID");

            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

            entity.HasOne(d => d.Commitee)
                .WithMany(p => p.CommiteeMember)
                .HasForeignKey(d => d.CommiteeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.CommiteeMember)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.CommiteeMember)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
