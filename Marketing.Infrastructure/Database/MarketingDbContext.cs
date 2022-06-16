using Marketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketing.Infrastructure.Database
{
    public class MarketingDbContext : DbContext
    {
        public MarketingDbContext(DbContextOptions<MarketingDbContext> options) : base(options) { }
        public DbSet<Distributor> Distributor { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Distributor>(entity => {
                entity.HasOne(x => x.Recomendator)
                    .WithMany(x => x.ChildDistributors)
                    .HasForeignKey(x => x.RecomendatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Sales>()
                .HasOne(x => x.Distributor)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.DistributorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Sales>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }

    }
}
