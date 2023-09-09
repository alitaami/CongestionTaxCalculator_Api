using CongestionTAxCalculator_Project.DB.Entities;
using CongestionTAxCalculator_Project.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace CongestionTAxCalculator_Project.DB
{
    namespace CongestionTaxCalculatorApp.Data
    {
        public class CongestionTaxContext : DbContext
        {
            public CongestionTaxContext(DbContextOptions<CongestionTaxContext> options)
                : base(options)
            {
            }

            public DbSet<TaxRule> TaxRules { get; set; }
            public DbSet<TimeRangeTax> TimeRangeTaxes { get; set; }
            public DbSet<ExemptionDates> ExemptionDates { get; set; }
            public DbSet<ExemptDaysOfWeek> ExemptDaysOfWeeks { get; set; }
            public DbSet<ExemptVehicleType> ExemptVehicleTypes { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                
                // Define the TaxRule entity
                modelBuilder.Entity<TaxRule>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.City).IsRequired();
                    entity.Property(e => e.StartDate).IsRequired();
                    entity.Property(e => e.EndDate).IsRequired();
          

                    // Configure a one-to-many relationship with TimeRanges
                    entity.HasMany(e => e.TimeRanges)
                        .WithOne()
                        .HasForeignKey(e => e.TaxRuleId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.ExemptionDates)
                      .WithOne()
                      .HasForeignKey(e => e.TaxRuleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.ExemptDaysOfWeek)
                      .WithOne()
                      .HasForeignKey(e => e.TaxRuleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                    entity.HasMany(e => e.ExemptVehicleTypes)
                      .WithOne()
                      .HasForeignKey(e => e.TaxRuleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
                });

                // Define the TimeRange entity
                modelBuilder.Entity<TimeRangeTax>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.StartTime).IsRequired();
                    entity.Property(e => e.EndTime).IsRequired();
                    entity.Property(e => e.TaxAmount).IsRequired();
                });

                modelBuilder.Entity<ExemptionDates>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.dateTime).IsRequired();
                });

                modelBuilder.Entity<ExemptDaysOfWeek>(entity =>
              {
                  entity.HasKey(e => e.Id);
                  entity.Property(e => e.DaysOfWeek).IsRequired();
              });

                modelBuilder.Entity<ExemptVehicleType>(entity =>
              {
                  entity.HasKey(e => e.Id);
                  entity.Property(e => e.TollFreeVehicles).IsRequired();
              });

                // Seed some tax rules
                modelBuilder.Entity<TaxRule>().HasData(
                    new TaxRule
                    {
                        Id = 1,
                        City = "Gothenburg",
                        StartDate = new DateTime(2013, 1, 1),
                        EndDate = new DateTime(2013, 12, 31),
                    },
                    new TaxRule
                    {
                        Id = 2,
                        City = "Stockholm",
                        StartDate = new DateTime(2013, 1, 1),
                        EndDate = new DateTime(2013, 12, 31),
                    }
                );

                modelBuilder.Entity<ExemptDaysOfWeek>().HasData(
                    new ExemptDaysOfWeek
                    {
                        Id = 1,
                        DaysOfWeek = DayOfWeek.Saturday,
                        TaxRuleId = 1,
                    },
                    new ExemptDaysOfWeek
                    {
                        Id = 2,
                        DaysOfWeek = DayOfWeek.Sunday,
                        TaxRuleId = 1,
                    }, 
                    new ExemptDaysOfWeek
                    {
                        Id = 3,
                        DaysOfWeek = DayOfWeek.Saturday,
                        TaxRuleId = 2,
                    },
                    new ExemptDaysOfWeek
                    {
                        Id = 4,
                        DaysOfWeek = DayOfWeek.Sunday,
                        TaxRuleId = 2,
                    }
                    ); 
                
                modelBuilder.Entity<ExemptVehicleType>().HasData(
                    new ExemptVehicleType
                    {
                        Id = 1,
                        TollFreeVehicles =VehicleTypes.Emergency,
                        TaxRuleId = 1,
                    },
                    new ExemptVehicleType
                    {
                        Id = 2,
                        TollFreeVehicles = VehicleTypes.Diplomat,
                        TaxRuleId = 1,
                    }, new ExemptVehicleType
                    {
                        Id = 3,
                        TollFreeVehicles = VehicleTypes.Military,
                        TaxRuleId = 2,
                    },
                    new ExemptVehicleType
                    {
                        Id = 4,
                        TollFreeVehicles = VehicleTypes.Emergency,
                        TaxRuleId = 2,
                    }, new ExemptVehicleType
                    {
                        Id = 5,
                        TollFreeVehicles = VehicleTypes.Military,
                        TaxRuleId = 1,
                    }, new ExemptVehicleType
                    {
                        Id = 6,
                        TollFreeVehicles = VehicleTypes.Foreign,
                        TaxRuleId = 1,
                    }, new ExemptVehicleType
                    {
                        Id = 7,
                        TollFreeVehicles = VehicleTypes.Tractor,
                        TaxRuleId = 1,
                    }
                    );

                modelBuilder.Entity<ExemptionDates>().HasData(
                // TaxRuleId =1
                new ExemptionDates
                {
                    Id = 1,
                    dateTime = new DateTime(2013, 1, 1),
                    TaxRuleId = 1
                },
                 new ExemptionDates
                 {
                     Id = 2,
                     dateTime = new DateTime(2013, 3, 28),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 3,
                     dateTime = new DateTime(2013, 3, 29),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 4,
                     dateTime = new DateTime(2013, 4, 1),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 5,
                     dateTime = new DateTime(2013, 4, 30),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 6,
                     dateTime = new DateTime(2013, 5, 1),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 7,
                     dateTime = new DateTime(2013, 5, 9),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 8,
                     dateTime = new DateTime(2013, 5, 8),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 9,
                     dateTime = new DateTime(2013, 6, 5),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 10,
                     dateTime = new DateTime(2013, 6, 6),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 11,
                     dateTime = new DateTime(2013, 6, 21),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 12,
                     dateTime = new DateTime(2013, 7, 1),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 13,
                     dateTime = new DateTime(2013, 11, 1),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 14,
                     dateTime = new DateTime(2013, 12, 24),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 15,
                     dateTime = new DateTime(2013, 12, 25),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 16,
                     dateTime = new DateTime(2013, 12, 26),
                     TaxRuleId = 1
                 },
                 new ExemptionDates
                 {
                     Id = 17,
                     dateTime = new DateTime(2013, 12, 31),
                     TaxRuleId = 1
                 },

                 // TaxRuleId =2
                 new ExemptionDates
                 {
                     Id = 18,
                     dateTime = new DateTime(2013, 1, 1),
                     TaxRuleId = 2
                 },
                 new ExemptionDates
                 {
                     Id = 19,
                     dateTime = new DateTime(2013, 12, 31),
                     TaxRuleId = 2
                 }
                 );

                modelBuilder.Entity<TimeRangeTax>().HasData(
                        // taxRuleID = 1    
                        new TimeRangeTax { Id = 1, StartTime = TimeSpan.FromHours(6), EndTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(29)), TaxAmount = 8, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 2, StartTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(59)), TaxAmount = 13, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 3, StartTime = TimeSpan.FromHours(7), EndTime = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)), TaxAmount = 18, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 4, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(29)), TaxAmount = 13, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 5, StartTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(14).Add(TimeSpan.FromMinutes(59)), TaxAmount = 8, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 6, StartTime = TimeSpan.FromHours(15), EndTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(29)), TaxAmount = 13, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 7, StartTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(16).Add(TimeSpan.FromMinutes(59)), TaxAmount = 18, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 8, StartTime = TimeSpan.FromHours(17), EndTime = TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(59)), TaxAmount = 13, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 9, StartTime = TimeSpan.FromHours(18), EndTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(29)), TaxAmount = 8, TaxRuleId = 1 },
                        new TimeRangeTax { Id = 10, StartTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(59)), TaxAmount = 0, TaxRuleId = 1 },

                        // taxRuleID = 2 
                        new TimeRangeTax { Id = 11, StartTime = TimeSpan.FromHours(6), EndTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(29)), TaxAmount = 8, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 12, StartTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(59)), TaxAmount = 3, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 13, StartTime = TimeSpan.FromHours(7), EndTime = TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(59)), TaxAmount = 18, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 14, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(29)), TaxAmount = 13, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 15, StartTime = TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(14).Add(TimeSpan.FromMinutes(59)), TaxAmount = 22, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 16, StartTime = TimeSpan.FromHours(15), EndTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(29)), TaxAmount = 13, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 17, StartTime = TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(16).Add(TimeSpan.FromMinutes(59)), TaxAmount = 43, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 18, StartTime = TimeSpan.FromHours(17), EndTime = TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(59)), TaxAmount = 23, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 19, StartTime = TimeSpan.FromHours(18), EndTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(29)), TaxAmount = 18, TaxRuleId = 2 },
                        new TimeRangeTax { Id = 20, StartTime = TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(30)), EndTime = TimeSpan.FromHours(5).Add(TimeSpan.FromMinutes(59)), TaxAmount = 0, TaxRuleId = 2 }
 ); ;
            }
        }
    }
}

