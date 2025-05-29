using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DispatchService.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Passport = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriverLicense = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsLowFloor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LicensePlate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehicleType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Route = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySchedules_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySchedules_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Address", "DriverLicense", "FirstName", "LastName", "Passport", "Patronymic", "Phone" },
                values: new object[,]
                {
                    { 1, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Иван", "Иванов", "1122 345678", "Иванович", "+74950198687" },
                    { 2, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Иван", "Федоров", "1122 345678", "Васильевич", "+74950198687" },
                    { 3, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Дмитрий", "Петров", "1122 345678", "Иванович", "+74950198687" },
                    { 4, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Василий", "Сидоров", "1122 345678", "Дмитриевич", "+74950198687" },
                    { 5, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Константин", "Иванов", "1122 345678", "Николаевич", "+74950198687" },
                    { 6, "Улица Пушкина Дом Колотушкина", "11 22 345678", "Иван", "Фролов", "1122 345678", "Дмитриевич", "+74950198687" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "IsLowFloor", "MaxCapacity", "ModelName" },
                values: new object[,]
                {
                    { 1, true, 82, "ЛиАЗ 4292" },
                    { 2, true, 117, "ЛиАЗ 5292" },
                    { 3, true, 100, "Адмирал 2022" },
                    { 4, true, 184, "Богатырь-М" },
                    { 5, true, 255, "Витязь-Ленинград" },
                    { 6, true, 190, "ЛиАЗ 6213" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "LicensePlate", "VehicleModelId", "VehicleType", "YearOfManufacture" },
                values: new object[,]
                {
                    { 1, "A123AA63", 1, "Bus", 2020 },
                    { 2, "A123AA63", 3, "Trolleybus", 2022 },
                    { 3, "A123AA63", 4, "Tram", 2021 },
                    { 4, "A123AA63", 2, "Bus", 2023 },
                    { 5, "A123AA63", 3, "Trolleybus", 2024 },
                    { 6, "A123AA63", 5, "Tram", 2021 }
                });

            migrationBuilder.InsertData(
                table: "DailySchedules",
                columns: new[] { "Id", "DriverId", "EndTime", "Route", "StartTime", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 5, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 9, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2025, 5, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2025, 5, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2025, 5, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, 6, new DateTime(2025, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 1, new DateTime(2025, 5, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 1, new DateTime(2025, 5, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 2, new DateTime(2025, 5, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, 2, new DateTime(2025, 5, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, 4, new DateTime(2025, 5, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, 5, new DateTime(2025, 5, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "52", new DateTime(2025, 5, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedules_DriverId",
                table: "DailySchedules",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedules_VehicleId",
                table: "DailySchedules",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySchedules");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleModels");
        }
    }
}
