using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CongestionTAxCalculator_Project.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExemptDaysOfWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysOfWeek = table.Column<int>(type: "int", nullable: false),
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExemptDaysOfWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExemptDaysOfWeeks_TaxRules_TaxRuleId",
                        column: x => x.TaxRuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExemptionDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExemptionDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExemptionDates_TaxRules_TaxRuleId",
                        column: x => x.TaxRuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExemptVehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TollFreeVehicles = table.Column<int>(type: "int", nullable: false),
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExemptVehicleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExemptVehicleTypes_TaxRules_TaxRuleId",
                        column: x => x.TaxRuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeRangeTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TaxAmount = table.Column<int>(type: "int", nullable: false),
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRangeTaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeRangeTaxes_TaxRules_TaxRuleId",
                        column: x => x.TaxRuleId,
                        principalTable: "TaxRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaxRules",
                columns: new[] { "Id", "City", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, "Gothenburg", new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Stockholm", new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ExemptDaysOfWeeks",
                columns: new[] { "Id", "DaysOfWeek", "TaxRuleId" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 0, 1 },
                    { 3, 6, 2 },
                    { 4, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ExemptVehicleTypes",
                columns: new[] { "Id", "TaxRuleId", "TollFreeVehicles" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 1, 4 },
                    { 3, 2, 6 },
                    { 4, 2, 3 },
                    { 5, 1, 6 },
                    { 6, 1, 5 },
                    { 7, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ExemptionDates",
                columns: new[] { "Id", "TaxRuleId", "dateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2013, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2013, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2013, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2013, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2013, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, new DateTime(2013, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, new DateTime(2013, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TimeRangeTaxes",
                columns: new[] { "Id", "EndTime", "StartTime", "TaxAmount", "TaxRuleId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 6, 29, 0, 0), new TimeSpan(0, 6, 0, 0, 0), 8, 1 },
                    { 2, new TimeSpan(0, 6, 59, 0, 0), new TimeSpan(0, 6, 30, 0, 0), 13, 1 },
                    { 3, new TimeSpan(0, 7, 59, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 18, 1 },
                    { 4, new TimeSpan(0, 8, 29, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 13, 1 },
                    { 5, new TimeSpan(0, 14, 59, 0, 0), new TimeSpan(0, 8, 30, 0, 0), 8, 1 },
                    { 6, new TimeSpan(0, 15, 29, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 13, 1 },
                    { 7, new TimeSpan(0, 16, 59, 0, 0), new TimeSpan(0, 15, 30, 0, 0), 18, 1 },
                    { 8, new TimeSpan(0, 17, 59, 0, 0), new TimeSpan(0, 17, 0, 0, 0), 13, 1 },
                    { 9, new TimeSpan(0, 18, 29, 0, 0), new TimeSpan(0, 18, 0, 0, 0), 8, 1 },
                    { 10, new TimeSpan(0, 5, 59, 0, 0), new TimeSpan(0, 18, 30, 0, 0), 0, 1 },
                    { 11, new TimeSpan(0, 6, 29, 0, 0), new TimeSpan(0, 6, 0, 0, 0), 8, 2 },
                    { 12, new TimeSpan(0, 6, 59, 0, 0), new TimeSpan(0, 6, 30, 0, 0), 13, 2 },
                    { 13, new TimeSpan(0, 7, 59, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 18, 2 },
                    { 14, new TimeSpan(0, 8, 29, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 13, 2 },
                    { 15, new TimeSpan(0, 14, 59, 0, 0), new TimeSpan(0, 8, 30, 0, 0), 8, 2 },
                    { 16, new TimeSpan(0, 15, 29, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 13, 2 },
                    { 17, new TimeSpan(0, 16, 59, 0, 0), new TimeSpan(0, 15, 30, 0, 0), 18, 2 },
                    { 18, new TimeSpan(0, 17, 59, 0, 0), new TimeSpan(0, 17, 0, 0, 0), 13, 2 },
                    { 19, new TimeSpan(0, 18, 29, 0, 0), new TimeSpan(0, 18, 0, 0, 0), 8, 2 },
                    { 20, new TimeSpan(0, 5, 59, 0, 0), new TimeSpan(0, 18, 30, 0, 0), 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExemptDaysOfWeeks_TaxRuleId",
                table: "ExemptDaysOfWeeks",
                column: "TaxRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExemptionDates_TaxRuleId",
                table: "ExemptionDates",
                column: "TaxRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExemptVehicleTypes_TaxRuleId",
                table: "ExemptVehicleTypes",
                column: "TaxRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRangeTaxes_TaxRuleId",
                table: "TimeRangeTaxes",
                column: "TaxRuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExemptDaysOfWeeks");

            migrationBuilder.DropTable(
                name: "ExemptionDates");

            migrationBuilder.DropTable(
                name: "ExemptVehicleTypes");

            migrationBuilder.DropTable(
                name: "TimeRangeTaxes");

            migrationBuilder.DropTable(
                name: "TaxRules");
        }
    }
}
