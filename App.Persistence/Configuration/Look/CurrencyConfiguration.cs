using App.Domain.Entity.look;
using Clean.Domain.Entity.look;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Currency = App.Domain.Entity.look.Currency;

namespace App.Persistence.Configuration.Look
{
    class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.ToTable("Currency", "look");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
        }
    }
}
