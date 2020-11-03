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

            modelBuilder.Entity<Services>().HasData(
                new Models.Services { Id = 1, Description = "Безлимитное количество напитков", Name = "Безлимитные напитки" },
                new Models.Services { Id = 2, Description = "Безлимитное количество снеков", Name = "Безлимитные снеки" },
                new Models.Services { Id = 3, Description = "Безлимитное количество блюд", Name = "Безлимитная еда" },
                new Models.Services { Id = 4, Description = "Русская баня", Name = "Баня" },
                new Models.Services { Id = 5, Description = "Финская сауна", Name = "Сауна" },
                new Models.Services { Id = 6, Description = "Массаж", Name = "Массаж" });

            modelBuilder.Entity<Attractions>().HasData(
                new Models.Attractions { Id = 1, Name = "Воздушный самолет", Description = "Мини-качели на башне", MaxFreeSeat = 10 },
                new Models.Attractions { Id = 2, Name = "Лягушка", Description = "Связанный 30-ти метровый аттракцион", MaxFreeSeat = 24 },
                new Models.Attractions { Id = 3, Name = "Прыгучие", Description = "Связанный аттракцион", MaxFreeSeat = 15 },
                new Models.Attractions { Id = 4, Name = "Американская горка L", Description = "Американская горка большая", MaxFreeSeat = 12 },
                new Models.Attractions { Id = 5, Name = "Американская горка S", Description = "Американская горка маленькая", MaxFreeSeat = 8 });

            modelBuilder.Entity<Subscriptions>().HasData(
                new Models.Subscriptions { Id = 1, Name = "Лайт", Description = "Все самое дешевое", AdultPrice = 320, ChildPrice = 250 },
                new Models.Subscriptions { Id = 2, Name = "Люкс", Description = "Все самое дорогое", AdultPrice = 599, ChildPrice = 399 });

            modelBuilder.Entity<AttractionList>().HasData(
                // Subscription Лайт
                new Models.AttractionList { Id = 1, AttractionId = 1, SubscriptionId = 1 },
                new Models.AttractionList { Id = 2, AttractionId = 2, SubscriptionId = 1 },
                new Models.AttractionList { Id = 3, AttractionId = 3, SubscriptionId = 1 },
                // Subscription Люкс
                new Models.AttractionList { Id = 4, AttractionId = 1, SubscriptionId = 2 },
                new Models.AttractionList { Id = 5, AttractionId = 2, SubscriptionId = 2 },
                new Models.AttractionList { Id = 6, AttractionId = 3, SubscriptionId = 2 },
                new Models.AttractionList { Id = 7, AttractionId = 4, SubscriptionId = 2 },
                new Models.AttractionList { Id = 8, AttractionId = 5, SubscriptionId = 2 });

            modelBuilder.Entity<ServiceList>().HasData(
                // Subscription Лайт
                new Models.ServiceList { Id = 1, ServiceId = 1, SubscriptionId = 1 },
                new Models.ServiceList { Id = 2, ServiceId = 2, SubscriptionId = 1 },
                new Models.ServiceList { Id = 3, ServiceId = 3, SubscriptionId = 1 },
                // Subscription Люкс
                new Models.ServiceList { Id = 4, ServiceId = 1, SubscriptionId = 2 },
                new Models.ServiceList { Id = 5, ServiceId = 2, SubscriptionId = 2 },
                new Models.ServiceList { Id = 6, ServiceId = 3, SubscriptionId = 2 },
                new Models.ServiceList { Id = 7, ServiceId = 4, SubscriptionId = 2 },
                new Models.ServiceList { Id = 8, ServiceId = 5, SubscriptionId = 2 },
                new Models.ServiceList { Id = 8, ServiceId = 6, SubscriptionId = 2 });


            
        }
    }
}
