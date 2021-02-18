using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Otopark.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore
{
    public class OtoparkDbContext:IdentityDbContext<Kullanici>
    {

        private const string ConnectionString = @"Server=DESKTOP-SL1S3RQ\SQLEXPRESS;Database=DboOtopark;Trusted_Connection=True;MultipleActiveResultSets=true";

        public OtoparkDbContext(DbContextOptions<OtoparkDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Konum> Konumlar { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            //Relationships
            builder.Entity<Arac>().HasOne(c => c.Fatura).WithOne(c => c.Arac).HasForeignKey<Fatura>(c => c.AracId);
            builder.Entity<Konum>().HasOne(c => c.Arac).WithOne(c => c.Konum).HasForeignKey<Arac>(c => c.KonumId);

            //Mapping
            builder.ApplyConfiguration(new AracMap());
            builder.ApplyConfiguration(new KonumMap());
            builder.ApplyConfiguration(new FaturaMap());
        }

    }
}
