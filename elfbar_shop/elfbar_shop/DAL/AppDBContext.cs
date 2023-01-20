using elfbar_shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.DAL
{
    public class AppDBContext : DbContext, IDisposable
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sell_info>().ToTable("Sell_info").HasKey(h => h.id);

            modelBuilder.Entity<Order_history>().ToTable("Order_history").HasKey(o => o.id);

            modelBuilder.Entity<Profiles>().ToTable("Profiles").HasKey(p => p.id);

            modelBuilder.Entity<Product>().ToTable("Product").HasKey(p => p.id);

            modelBuilder.Entity<Types>().ToTable("Types").HasKey(c => c.id);

            modelBuilder.Entity<Spends>().ToTable("Spends").HasKey(b => b.id);

            modelBuilder.Entity<Wirehouses>().ToTable("Wirehouses").HasKey(c => c.id);

            modelBuilder.Entity<Laugh>().ToTable("Laugh").HasKey(b => b.id);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Sell_info> Sell_info { get; set; }

        public DbSet<Order_history> Order_history { get; set; }

        public DbSet<Profiles> Profiles { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Types> Types { get; set; }

        public DbSet<Laugh> Laugh { get; set; }

        public DbSet<Spends> Spends { get; set; }

        public DbSet<Wirehouses> Wirehouses { get; set; }
    }
}
