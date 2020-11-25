﻿// <auto-generated />
using System;
using AmusementPark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmusementPark.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmusementPark.Models.Attraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxFreeSeat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attractions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Мини-качели на башне",
                            MaxFreeSeat = 10,
                            Name = "Воздушный самолет"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Связанный 30-ти метровый аттракцион",
                            MaxFreeSeat = 24,
                            Name = "Лягушка"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Связанный аттракцион",
                            MaxFreeSeat = 15,
                            Name = "Прыгучие"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Американская горка большая",
                            MaxFreeSeat = 12,
                            Name = "Американская горка L"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Американская горка маленькая",
                            MaxFreeSeat = 8,
                            Name = "Американская горка S"
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<int>("AdultTickets")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<int>("ChildTickets")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("AmusementPark.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Link")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AmusementPark.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Безлимитное количество напитков",
                            Name = "Безлимитные напитки"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Безлимитное количество снеков",
                            Name = "Безлимитные снеки"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Безлимитное количество блюд",
                            Name = "Безлимитная еда"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Русская баня",
                            Name = "Баня"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Финская сауна",
                            Name = "Сауна"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Массаж",
                            Name = "Массаж"
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AdultPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ChildPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdultPrice = 320m,
                            ChildPrice = 250m,
                            Description = "Все самое дешевое",
                            Name = "Лайт"
                        },
                        new
                        {
                            Id = 2,
                            AdultPrice = 599m,
                            ChildPrice = 399m,
                            Description = "Все самое дорогое",
                            Name = "Люкс"
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.SubscriptionAttraction", b =>
                {
                    b.Property<int>("AttractionId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("AttractionId", "SubscriptionId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionAttractions");

                    b.HasData(
                        new
                        {
                            AttractionId = 1,
                            SubscriptionId = 1
                        },
                        new
                        {
                            AttractionId = 2,
                            SubscriptionId = 1
                        },
                        new
                        {
                            AttractionId = 3,
                            SubscriptionId = 1
                        },
                        new
                        {
                            AttractionId = 1,
                            SubscriptionId = 2
                        },
                        new
                        {
                            AttractionId = 2,
                            SubscriptionId = 2
                        },
                        new
                        {
                            AttractionId = 3,
                            SubscriptionId = 2
                        },
                        new
                        {
                            AttractionId = 4,
                            SubscriptionId = 2
                        },
                        new
                        {
                            AttractionId = 5,
                            SubscriptionId = 2
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.SubscriptionService", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId", "SubscriptionId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionServices");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            SubscriptionId = 1
                        },
                        new
                        {
                            ServiceId = 2,
                            SubscriptionId = 1
                        },
                        new
                        {
                            ServiceId = 3,
                            SubscriptionId = 1
                        },
                        new
                        {
                            ServiceId = 1,
                            SubscriptionId = 2
                        },
                        new
                        {
                            ServiceId = 2,
                            SubscriptionId = 2
                        },
                        new
                        {
                            ServiceId = 3,
                            SubscriptionId = 2
                        },
                        new
                        {
                            ServiceId = 4,
                            SubscriptionId = 2
                        },
                        new
                        {
                            ServiceId = 5,
                            SubscriptionId = 2
                        },
                        new
                        {
                            ServiceId = 6,
                            SubscriptionId = 2
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.Booking", b =>
                {
                    b.HasOne("AmusementPark.Models.Client", "Client")
                        .WithMany("Bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AmusementPark.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AmusementPark.Models.SubscriptionAttraction", b =>
                {
                    b.HasOne("AmusementPark.Models.Attraction", "Attraction")
                        .WithMany("SubscriptionAttraction")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AmusementPark.Models.Subscription", "Subscription")
                        .WithMany("SubscriptionAttractions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AmusementPark.Models.SubscriptionService", b =>
                {
                    b.HasOne("AmusementPark.Models.Service", "Service")
                        .WithMany("SubscriptionServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AmusementPark.Models.Subscription", "Subscription")
                        .WithMany("SubscriptionServices")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
