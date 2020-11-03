using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AttractionList> AttractionList { get; set; }
        public DbSet<Attractions> Attractions { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ServiceList> ServiceList { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttractionList>()
                .HasKey(c => new { c.AttractionId, c.SubscriptionId });
            modelBuilder.Entity<ServiceList>()
                .HasKey(c => new { c.ServiceId, c.SubscriptionId });
        }
    }
}
