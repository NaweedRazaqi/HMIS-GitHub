using App.Domain.Entity.prf;
using App.Domain.Entity.rep;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class DbobjectConfiguration : IEntityTypeConfiguration<Dbobject>
    {
        public void Configure(EntityTypeBuilder<Dbobject> entity)
        {
            entity.ToTable("DBObject", "rep");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Dbname).HasColumnName("DBName");

            entity.Property(e => e.Fkey).HasColumnName("FKey");

            entity.Property(e => e.Pkey).HasColumnName("PKey");
        }
    }
}
