using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AracMap : IEntityTypeConfiguration<Arac>
    {
        public void Configure(EntityTypeBuilder<Arac> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.TcKimlikNo).HasMaxLength(11).IsRequired();
            builder.Property(c => c.Ad).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Soyad).HasMaxLength(50).IsRequired();
            builder.Property(c => c.TelefonNo).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Plaka).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Marka).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Model).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Renk).HasMaxLength(50).IsRequired();
            builder.Property(c => c.KonumId).IsRequired();

            builder.ToTable("Araclar");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.TcKimlikNo).HasColumnName("TcKimlikNo");
            builder.Property(c => c.Ad).HasColumnName("Ad");
            builder.Property(c => c.Soyad).HasColumnName("Soyad");
            builder.Property(c => c.TelefonNo).HasColumnName("TelefonNo");
            builder.Property(c => c.Plaka).HasColumnName("Plaka");
            builder.Property(c => c.Marka).HasColumnName("Marka");
            builder.Property(c => c.Model).HasColumnName("Model");
            builder.Property(c => c.Renk).HasColumnName("Renk");
            builder.Property(c => c.KonumId).HasColumnName("KonumId");
        }
    }
}
