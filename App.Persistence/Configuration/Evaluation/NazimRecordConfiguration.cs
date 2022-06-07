using App.Domain.Entity.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Doc
{
    public class NazimRecordConfiguration : IEntityTypeConfiguration<Nerecords>
    {
        public void Configure(EntityTypeBuilder<Nerecords> entity)
        {
            entity.ToTable("NERecords", "NE");

            entity.HasIndex(e => e.Evid)
                .HasName("fki_FK_record_category");

            entity.HasIndex(e => e.MarkId)
                .HasName("fki_FK_NER_Marks");

            entity.HasIndex(e => e.Nid)
                .HasName("fki_FK_NER_Nazim");

            entity.HasIndex(e => e.ZoneId)
                .HasName("fki_FK_record_Zone");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.CreatedOn).HasColumnName("CreatedON");

            entity.Property(e => e.Evid).HasColumnName("EVID");

            entity.Property(e => e.MarkId).HasColumnName("MarkID");

            entity.Property(e => e.ModifiedBy).HasColumnType("character varying");

            entity.Property(e => e.ModifiedOn).HasColumnName("ModifiedON");

            entity.Property(e => e.Nid).HasColumnName("NID");

            entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

            entity.HasOne(d => d.Ev)
                .WithMany(p => p.Nerecords)
                .HasForeignKey(d => d.Evid)
                .HasConstraintName("FK_record_category");

            entity.HasOne(d => d.Mark)
                .WithMany(p => p.Nerecords)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("FK_NER_Marks");

            entity.HasOne(d => d.N)
                .WithMany(p => p.Nerecords)
                .HasForeignKey(d => d.Nid)
                .HasConstraintName("FK_NER_Nazim");

            entity.HasOne(d => d.Zone)
                .WithMany(p => p.Nerecords)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("FK_record_Zone");
        }
    }
}
