using IncidentReport.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IncidentReport.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contact>()
            //    .HasMany(c => c.Accounts); 
            //modelBuilder.Entity<Account>()
            //    .HasMany(a => a.Incidents)
            //    .WithOne(i => i.Account)
            //    .HasForeignKey(i => i.AccountId);
            //modelBuilder.Entity<Account>()
            //    .HasIndex(a => a.Name)
            //    .IsUnique();
            //modelBuilder.Entity<Contact>()
            //    .HasIndex(c => c.Email)
            //    .IsUnique();
            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Contact)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Account)
                .WithMany(a => a.Incidents)
                .HasForeignKey(i => i.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
