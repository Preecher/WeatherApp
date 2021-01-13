using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZipCode = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipWeather",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    WeatherDescription = table.Column<string>(nullable: true),
                    Temp = table.Column<double>(nullable: false),
                    TempLow = table.Column<double>(nullable: false),
                    TempHigh = table.Column<double>(nullable: false),
                    WindSpeed = table.Column<string>(nullable: true),
                    Cloud = table.Column<string>(nullable: true),
                    Pressure = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    WeatherDate = table.Column<DateTime>(nullable: false),
                    DataRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipWeather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZipWeather_DataRequest_DataRequestId",
                        column: x => x.DataRequestId,
                        principalTable: "DataRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZipWeather_DataRequestId",
                table: "ZipWeather",
                column: "DataRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZipWeather");

            migrationBuilder.DropTable(
                name: "DataRequest");
        }
    }
}
