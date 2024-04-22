using System;
using Kachow.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Kachow.Server.Data
{

    public class DataContext : DbContext
    {

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=education;Username=postgres;Password=password")
                    .UseSnakeCaseNamingConvention()
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Worker>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Feedback>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Parcel>().Property(p => p.Id).ValueGeneratedOnAdd();
                modelBuilder.Entity<DeliveryMethod>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DeliveryStatus>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RefundCases>().Property(p => p.Id).ValueGeneratedOnAdd();
                modelBuilder.Entity<ParcelName>().Property(p => p.Id).ValueGeneratedOnAdd();
                modelBuilder.Entity<User>().HasMany(cu => cu.Parcels).WithOne(pa => pa.User);
            modelBuilder.Entity<User>().HasMany(cu => cu.RefundCases).WithOne(rc => rc.User);
            modelBuilder.Entity<Parcel>().HasOne(d => d.Feedback).WithOne(pa => pa.Parcel).HasForeignKey<Feedback>(f => f.ParcelForeignKey);
            modelBuilder.Entity<Worker>().HasMany(d => d.Feedbacks).WithOne(pa => pa.Worker);
            modelBuilder.Entity<DeliveryMethod>().HasMany(d => d.Parcels).WithOne(pa => pa.DeliveryMethod);
                modelBuilder.Entity<DeliveryStatus>().HasMany(ds => ds.Parcels).WithOne(pa => pa.DeliveryStatus);
                modelBuilder.Entity<ParcelName>().HasMany(pn => pn.Parcels).WithOne(pa => pa.ParcelName);

            }



            public DbSet<Parcel> Parcels { get; set; }
            public DbSet<ParcelName> ParcelNames { get; set; }
            public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
            public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
            public DbSet<RefundCases> RefundCases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Worker> Workers { get; set; }

    }
}

