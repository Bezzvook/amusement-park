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

            modelBuilder.Entity("AmusementPark.Models.AttractionList", b =>
                {
                    b.Property<int>("AttractionId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("AttractionId", "SubscriptionId");

                    b.ToTable("AttractionList");

                    b.HasData(
                        new
                        {
                            AttractionId = 1,
                            SubscriptionId = 1,
                            Id = 1
                        },
                        new
                        {
                            AttractionId = 2,
                            SubscriptionId = 1,
                            Id = 2
                        },
                        new
                        {
                            AttractionId = 3,
                            SubscriptionId = 1,
                            Id = 3
                        },
                        new
                        {
                            AttractionId = 1,
                            SubscriptionId = 2,
                            Id = 4
                        },
                        new
                        {
                            AttractionId = 2,
                            SubscriptionId = 2,
                            Id = 5
                        },
                        new
                        {
                            AttractionId = 3,
                            SubscriptionId = 2,
                            Id = 6
                        },
                        new
                        {
                            AttractionId = 4,
                            SubscriptionId = 2,
                            Id = 7
                        },
                        new
                        {
                            AttractionId = 5,
                            SubscriptionId = 2,
                            Id = 8
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.Attractions", b =>
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

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("AmusementPark.Models.Clients", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumber");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AmusementPark.Models.ServiceList", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ServiceId", "SubscriptionId");

                    b.ToTable("ServiceList");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            SubscriptionId = 1,
                            Id = 1
                        },
                        new
                        {
                            ServiceId = 2,
                            SubscriptionId = 1,
                            Id = 2
                        },
                        new
                        {
                            ServiceId = 3,
                            SubscriptionId = 1,
                            Id = 3
                        },
                        new
                        {
                            ServiceId = 1,
                            SubscriptionId = 2,
                            Id = 4
                        },
                        new
                        {
                            ServiceId = 2,
                            SubscriptionId = 2,
                            Id = 5
                        },
                        new
                        {
                            ServiceId = 3,
                            SubscriptionId = 2,
                            Id = 6
                        },
                        new
                        {
                            ServiceId = 4,
                            SubscriptionId = 2,
                            Id = 7
                        },
                        new
                        {
                            ServiceId = 5,
                            SubscriptionId = 2,
                            Id = 8
                        },
                        new
                        {
                            ServiceId = 6,
                            SubscriptionId = 2,
                            Id = 8
                        });
                });

            modelBuilder.Entity("AmusementPark.Models.Services", b =>
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

            modelBuilder.Entity("AmusementPark.Models.Subscriptions", b =>
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
#pragma warning restore 612, 618
        }
    }
}
