using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<SubscriptionService> SubscriptionServices { get; set; }
        public DbSet<SubscriptionAttraction> SubscriptionAttractions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionAttraction>()
                .HasKey(c => new { c.AttractionId, c.SubscriptionId });
            modelBuilder.Entity<SubscriptionService>()
                .HasKey(c => new { c.ServiceId, c.SubscriptionId });

            modelBuilder.Entity<Service>().HasData(
                new Models.Service { Id = 1, Description = "Безлимитное количество напитков", Name = "Безлимитные напитки" },
                new Models.Service { Id = 2, Description = "Безлимитное количество снеков", Name = "Безлимитные снеки" },
                new Models.Service { Id = 3, Description = "Безлимитное количество блюд", Name = "Безлимитная еда" },
                new Models.Service { Id = 4, Description = "Русская баня", Name = "Баня" },
                new Models.Service { Id = 5, Description = "Финская сауна", Name = "Сауна" },
                new Models.Service { Id = 6, Description = "Массаж", Name = "Массаж" });

            modelBuilder.Entity<Attraction>().HasData(
                new Models.Attraction { Id = 1, Name = "Воздушный самолет", Description = "Мини-качели на башне", MaxFreeSeat = 10 },
                new Models.Attraction { Id = 2, Name = "Лягушка", Description = "Связанный 30-ти метровый аттракцион", MaxFreeSeat = 24 },
                new Models.Attraction { Id = 3, Name = "Прыгучие", Description = "Связанный аттракцион", MaxFreeSeat = 15 },
                new Models.Attraction { Id = 4, Name = "Американская горка L", Description = "Американская горка большая", MaxFreeSeat = 12 },
                new Models.Attraction { Id = 5, Name = "Американская горка S", Description = "Американская горка маленькая", MaxFreeSeat = 8 });

            modelBuilder.Entity<Subscription>().HasData(
                new Models.Subscription { Id = 1, Name = "Лайт", Description = "Все самое дешевое", AdultPrice = 320, ChildPrice = 250 },
                new Models.Subscription { Id = 2, Name = "Люкс", Description = "Все самое дорогое", AdultPrice = 599, ChildPrice = 399 });

            modelBuilder.Entity<SubscriptionAttraction>().HasData(
                // Subscription Лайт
                new Models.SubscriptionAttraction { Id = 1, AttractionId = 1, SubscriptionId = 1 },
                new Models.SubscriptionAttraction { Id = 2, AttractionId = 2, SubscriptionId = 1 },
                new Models.SubscriptionAttraction { Id = 3, AttractionId = 3, SubscriptionId = 1 },
                // Subscription Люкс
                new Models.SubscriptionAttraction { Id = 4, AttractionId = 1, SubscriptionId = 2 },
                new Models.SubscriptionAttraction { Id = 5, AttractionId = 2, SubscriptionId = 2 },
                new Models.SubscriptionAttraction { Id = 6, AttractionId = 3, SubscriptionId = 2 },
                new Models.SubscriptionAttraction { Id = 7, AttractionId = 4, SubscriptionId = 2 },
                new Models.SubscriptionAttraction { Id = 8, AttractionId = 5, SubscriptionId = 2 });

            modelBuilder.Entity<SubscriptionService>().HasData(
                // Subscription Лайт
                new Models.SubscriptionService { Id = 1, ServiceId = 1, SubscriptionId = 1 },
                new Models.SubscriptionService { Id = 2, ServiceId = 2, SubscriptionId = 1 },
                new Models.SubscriptionService { Id = 3, ServiceId = 3, SubscriptionId = 1 },
                // Subscription Люкс
                new Models.SubscriptionService { Id = 4, ServiceId = 1, SubscriptionId = 2 },
                new Models.SubscriptionService { Id = 5, ServiceId = 2, SubscriptionId = 2 },
                new Models.SubscriptionService { Id = 6, ServiceId = 3, SubscriptionId = 2 },
                new Models.SubscriptionService { Id = 7, ServiceId = 4, SubscriptionId = 2 },
                new Models.SubscriptionService { Id = 8, ServiceId = 5, SubscriptionId = 2 },
                new Models.SubscriptionService { Id = 8, ServiceId = 6, SubscriptionId = 2 });
        }
    }
}
