using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebHostel.Domain.Entity;
using WebHostel.Models;

namespace WorkerService1
{

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hostel>().ToTable("Hostel").HasKey(h => h.id);
            modelBuilder.Entity<Hostel_info>().ToTable("Hostel_info").HasKey(h => h.hostel_id);
            modelBuilder.Entity<Profiles>().ToTable("Profiles").HasKey(p => p.id);
            modelBuilder.Entity<Customers>().ToTable("Customers").HasKey(p => p.id);
            modelBuilder.Entity<Cafe>().ToTable("Cafe").HasKey(c => c.hostel_id);
            modelBuilder.Entity<Booking>().ToTable("Booking").HasKey(b => b.id);

            modelBuilder.Entity<chosen_services>().ToTable("chosen_services").HasKey(h => h.id);
            modelBuilder.Entity<Dishes>().ToTable("Dishes").HasKey(h => h.id);
            modelBuilder.Entity<Documentation>().ToTable("Documentation").HasKey(p => p.id);
            modelBuilder.Entity<Orders>().ToTable("Orders").HasKey(p => p.id);
            modelBuilder.Entity<Rooms>().ToTable("Rooms").HasKey(c => c.id);
            modelBuilder.Entity<Booking>().ToTable("Booking").HasKey(b => b.rooms_id);

            modelBuilder.Entity<Cafe_employees>().ToTable("Cafe_employees").HasKey(h => h.id);
            modelBuilder.Entity<Checks>().ToTable("Checks").HasKey(h => h.id);
            modelBuilder.Entity<Checks_history>().ToTable("Checks_history").HasKey(p => p.id);
            modelBuilder.Entity<Employees>().ToTable("Employees").HasKey(c => c.id);
            modelBuilder.Entity<foods>().ToTable("foods").HasKey(b => b.id);

            modelBuilder.Entity<Manufactorer>().ToTable("Manufactorer").HasKey(h => h.id);
            modelBuilder.Entity<ordered_products>().ToTable("ordered_products").HasKey(h => h.id);
            modelBuilder.Entity<orders_history>().ToTable("orders_history").HasKey(p => p.id);
            modelBuilder.Entity<Sanitation>().ToTable("Sanitation").HasKey(p => p.id);
            modelBuilder.Entity<Service>().ToTable("Services").HasKey(c => c.id);
            modelBuilder.Entity<Services_history>().ToTable("Services_history").HasKey(b => b.id);

            modelBuilder.Entity<techs>().ToTable("techs").HasKey(h => h.id);
            modelBuilder.Entity<worders>().ToTable("worders").HasKey(h => h.id);
            modelBuilder.Entity<Wirehouse>().ToTable("Wirehouse").HasKey(p => p.hostel_id);
            modelBuilder.Entity<Wirehouse_employees>().ToTable("Wirehouse_employees").HasKey(p => p.id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<chosen_services> chosen_services { get; set; }

        public DbSet<Hostel> Hostel { get; set; }

        public DbSet<Hostel_info> Hostel_info { get; set; }

        public DbSet<Cafe> Cafe { get; set; }

        public DbSet<Cars> Cars { get; set; }

        public DbSet<Checks> Checks { get; set; }

        public DbSet<Checks_history> Checks_history { get; set; }

        public DbSet<Dishes> Dishes { get; set; }

        public DbSet<Documentation> Documentation { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Profiles> Profiles { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<Services_info> Services_info { get; set; }

        public DbSet<Services_history> Services_history { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<Cafe_employees> Cafe_employees { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Wirehouse_employees> Wirehouse_employees { get; set; }

        public DbSet<foods> foods { get; set; }

        public DbSet<Manufactorer> Manufactorer { get; set; }

        public DbSet<ordered_products> ordered_products { get; set; }

        public DbSet<orders_history> orders_history { get; set; }

        public DbSet<Sanitation> Sanitation { get; set; }

        public DbSet<techs> techs { get; set; }

        public DbSet<worders> worders { get; set; }

        public DbSet<Wirehouse> Wirehouse { get; set; }

        public DbSet<Employee_spends> Employee_spends { get; set; }
    }

}
