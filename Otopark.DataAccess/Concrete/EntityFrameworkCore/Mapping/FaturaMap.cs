using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class FaturaMap : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.ParkSuresi).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Ucret).IsRequired();
            builder.Property(c => c.Tarih).IsRequired();
            builder.Property(c => c.AracId).IsRequired();

            builder.ToTable("Faturalar");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.ParkSuresi).HasColumnName("ParkSuresi");
            builder.Property(c => c.Ucret).HasColumnName("Ucret");
            builder.Property(c => c.Tarih).HasColumnName("Tarih");
            builder.Property(c => c.AracId).HasColumnName("AracId");
        }
    }
}
