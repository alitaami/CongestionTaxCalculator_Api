﻿// <auto-generated />
using System;
using CongestionTAxCalculator_Project.DB.CongestionTaxCalculatorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CongestionTAxCalculator_Project.Migrations
{
    [DbContext(typeof(CongestionTaxContext))]
    [Migration("20230909111340_initialDB")]
    partial class initialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CongestionTAxCalculator_Project.DB.Entities.TaxRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaxRules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gothenburg",
                            EndDate = new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            EndDate = new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.DB.Entities.TimeRangeTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("TaxAmount")
                        .HasColumnType("int");

                    b.Property<int>("TaxRuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxRuleId");

                    b.ToTable("TimeRangeTaxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeSpan(0, 6, 29, 0, 0),
                            StartTime = new TimeSpan(0, 6, 0, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new TimeSpan(0, 6, 59, 0, 0),
                            StartTime = new TimeSpan(0, 6, 30, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new TimeSpan(0, 7, 59, 0, 0),
                            StartTime = new TimeSpan(0, 7, 0, 0, 0),
                            TaxAmount = 18,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 4,
                            EndTime = new TimeSpan(0, 8, 29, 0, 0),
                            StartTime = new TimeSpan(0, 8, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 5,
                            EndTime = new TimeSpan(0, 14, 59, 0, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 6,
                            EndTime = new TimeSpan(0, 15, 29, 0, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 7,
                            EndTime = new TimeSpan(0, 16, 59, 0, 0),
                            StartTime = new TimeSpan(0, 15, 30, 0, 0),
                            TaxAmount = 18,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 8,
                            EndTime = new TimeSpan(0, 17, 59, 0, 0),
                            StartTime = new TimeSpan(0, 17, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 9,
                            EndTime = new TimeSpan(0, 18, 29, 0, 0),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 10,
                            EndTime = new TimeSpan(0, 5, 59, 0, 0),
                            StartTime = new TimeSpan(0, 18, 30, 0, 0),
                            TaxAmount = 0,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 11,
                            EndTime = new TimeSpan(0, 6, 29, 0, 0),
                            StartTime = new TimeSpan(0, 6, 0, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 12,
                            EndTime = new TimeSpan(0, 6, 59, 0, 0),
                            StartTime = new TimeSpan(0, 6, 30, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 13,
                            EndTime = new TimeSpan(0, 7, 59, 0, 0),
                            StartTime = new TimeSpan(0, 7, 0, 0, 0),
                            TaxAmount = 18,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 14,
                            EndTime = new TimeSpan(0, 8, 29, 0, 0),
                            StartTime = new TimeSpan(0, 8, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 15,
                            EndTime = new TimeSpan(0, 14, 59, 0, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 16,
                            EndTime = new TimeSpan(0, 15, 29, 0, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 17,
                            EndTime = new TimeSpan(0, 16, 59, 0, 0),
                            StartTime = new TimeSpan(0, 15, 30, 0, 0),
                            TaxAmount = 18,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 18,
                            EndTime = new TimeSpan(0, 17, 59, 0, 0),
                            StartTime = new TimeSpan(0, 17, 0, 0, 0),
                            TaxAmount = 13,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 19,
                            EndTime = new TimeSpan(0, 18, 29, 0, 0),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0),
                            TaxAmount = 8,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 20,
                            EndTime = new TimeSpan(0, 5, 59, 0, 0),
                            StartTime = new TimeSpan(0, 18, 30, 0, 0),
                            TaxAmount = 0,
                            TaxRuleId = 2
                        });
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptDaysOfWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DaysOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("TaxRuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxRuleId");

                    b.ToTable("ExemptDaysOfWeeks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DaysOfWeek = 6,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 2,
                            DaysOfWeek = 0,
                            TaxRuleId = 1
                        },
                        new
                        {
                            Id = 3,
                            DaysOfWeek = 6,
                            TaxRuleId = 2
                        },
                        new
                        {
                            Id = 4,
                            DaysOfWeek = 0,
                            TaxRuleId = 2
                        });
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptVehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TaxRuleId")
                        .HasColumnType("int");

                    b.Property<int>("TollFreeVehicles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxRuleId");

                    b.ToTable("ExemptVehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TaxRuleId = 1,
                            TollFreeVehicles = 3
                        },
                        new
                        {
                            Id = 2,
                            TaxRuleId = 1,
                            TollFreeVehicles = 4
                        },
                        new
                        {
                            Id = 3,
                            TaxRuleId = 2,
                            TollFreeVehicles = 6
                        },
                        new
                        {
                            Id = 4,
                            TaxRuleId = 2,
                            TollFreeVehicles = 3
                        },
                        new
                        {
                            Id = 5,
                            TaxRuleId = 1,
                            TollFreeVehicles = 6
                        },
                        new
                        {
                            Id = 6,
                            TaxRuleId = 1,
                            TollFreeVehicles = 5
                        },
                        new
                        {
                            Id = 7,
                            TaxRuleId = 1,
                            TollFreeVehicles = 2
                        });
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptionDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TaxRuleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaxRuleId");

                    b.ToTable("ExemptionDates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            TaxRuleId = 1,
                            dateTime = new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            TaxRuleId = 2,
                            dateTime = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 19,
                            TaxRuleId = 2,
                            dateTime = new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.DB.Entities.TimeRangeTax", b =>
                {
                    b.HasOne("CongestionTAxCalculator_Project.DB.Entities.TaxRule", null)
                        .WithMany("TimeRanges")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptDaysOfWeek", b =>
                {
                    b.HasOne("CongestionTAxCalculator_Project.DB.Entities.TaxRule", null)
                        .WithMany("ExemptDaysOfWeek")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptVehicleType", b =>
                {
                    b.HasOne("CongestionTAxCalculator_Project.DB.Entities.TaxRule", null)
                        .WithMany("ExemptVehicleTypes")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.Data.Entities.ExemptionDates", b =>
                {
                    b.HasOne("CongestionTAxCalculator_Project.DB.Entities.TaxRule", null)
                        .WithMany("ExemptionDates")
                        .HasForeignKey("TaxRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CongestionTAxCalculator_Project.DB.Entities.TaxRule", b =>
                {
                    b.Navigation("ExemptDaysOfWeek");

                    b.Navigation("ExemptVehicleTypes");

                    b.Navigation("ExemptionDates");

                    b.Navigation("TimeRanges");
                });
#pragma warning restore 612, 618
        }
    }
}
