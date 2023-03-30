using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Entities;

namespace WEBSHOP.DAL
{
    public class AppDBContext : DbContext, IDisposable
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(C => C.Id);
            modelBuilder.Entity<Orders>().ToTable("Orders").HasKey(O => O.Id);
            modelBuilder.Entity<Bin>().ToTable("Bin").HasKey(B => B.Id);
            modelBuilder.Entity<Types>().ToTable("Types").HasKey(T => T.Id);
            modelBuilder.Entity<Manufactorer>().ToTable("Manufactorer").HasKey(M => M.Id);
            modelBuilder.Entity<Unit>().ToTable("Unit").HasKey(U => U.Id);
            modelBuilder.Entity<Product>().ToTable("Product").HasKey(A => A.Id);
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod").HasKey(A => A.Id);
            modelBuilder.Entity<OrderHasProduct>().ToTable("OrderHasProduct").HasKey(x=>x.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bin> Bin { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Manufactorer> Manufactorer { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<OrderHasProduct> OrderHasProduct { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
    }
}
