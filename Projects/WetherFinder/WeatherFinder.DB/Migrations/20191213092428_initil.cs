using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherFinder.DB.Migrations
{
    public partial class initil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CustomMessage = table.Column<string>(nullable: true),
                    CustomStackTrace = table.Column<string>(nullable: true),
                    InnerMessage = table.Column<string>(nullable: true),
                    InnerStackTrace = table.Column<string>(nullable: true),
                    InnerSource = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ClientErrorMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    TemperatureC = table.Column<double>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    Pressure = table.Column<double>(nullable: false),
                    Wind = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exceptions");

            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
