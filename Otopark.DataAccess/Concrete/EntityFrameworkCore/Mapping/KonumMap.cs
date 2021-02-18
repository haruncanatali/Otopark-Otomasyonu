using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class KonumMap : IEntityTypeConfiguration<Konum>
    {
        public void Configure(EntityTypeBuilder<Konum> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.Kat).IsRequired();
            builder.Property(c => c.Cephe).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Durum).IsRequired();
            builder.Property(c => c.Yer).IsRequired().HasMaxLength(25);

            builder.ToTable("Konumlar");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Kat).HasColumnName("Kat");
            builder.Property(c => c.Yer).HasColumnName("Yer");
            builder.Property(c => c.Cephe).HasColumnName("Cephe");
            builder.Property(c => c.Durum).HasColumnName("Durum");
        }
    }
}
