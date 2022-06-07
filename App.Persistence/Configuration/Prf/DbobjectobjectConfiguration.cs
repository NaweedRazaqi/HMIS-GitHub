using App.Domain.Entity.prf;
using App.Domain.Entity.rep;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configuration.Prf
{
    public class DbobjectObjectConfiguration : IEntityTypeConfiguration<DbobjectObject>
    {
        public void Configure(EntityTypeBuilder<DbobjectObject> entity)
        {
            entity.ToTable("DBObjectObject", "rep");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ChildId).HasColumnName("ChildID");

            entity.Property(e => e.ParentId).HasColumnName("ParentID");
        }
    }
}
