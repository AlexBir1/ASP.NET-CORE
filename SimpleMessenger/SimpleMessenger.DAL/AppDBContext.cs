using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleMessenger.Shared;
using System;

namespace SimpleMessenger.DAL
{
    public class AppDBContext : IdentityDbContext
    {
        public DbSet<Message> Message { get; set; }
        public DbSet<Chat> Chat { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Chat>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(x => x.Messages).WithOne(x => x.Chat).HasForeignKey(x=>x.Chat_Id);
            });

            builder.Entity<Account>(x => { });

            builder.Entity<Message>(x => 
            {
                x.HasKey(x => x.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
