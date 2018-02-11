using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ITGigs.DB.Migrations
{
    public partial class jojo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomExceptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CustomInnerMessage = table.Column<string>(nullable: true),
                    CustomInnerStackTrace = table.Column<string>(nullable: true),
                    CustomMessage = table.Column<string>(nullable: true),
                    CustomStackTrace = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    HResult = table.Column<int>(nullable: false),
                    HelpLink = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateChanged = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    ValidationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITGigs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PerformerId = table.Column<string>(nullable: true),
                    TicketPrice = table.Column<int>(nullable: false),
                    VenueId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITGigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITGigs_Users_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITGigs_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITGigs_PerformerId",
                table: "ITGigs",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_ITGigs_VenueId",
                table: "ITGigs",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomExceptions");

            migrationBuilder.DropTable(
                name: "ITGigs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
