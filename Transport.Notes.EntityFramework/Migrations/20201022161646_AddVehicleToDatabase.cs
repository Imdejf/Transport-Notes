using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transport.Notes.EntityFramework.Migrations
{
    public partial class AddVehicleToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carBrand = table.Column<string>(nullable: true),
                    VIN = table.Column<string>(nullable: true),
                    Milage = table.Column<string>(nullable: true),
                    EnigneNumber = table.Column<string>(nullable: true),
                    EngineCapacity = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    FirstRegistration = table.Column<DateTime>(nullable: false),
                    YearPurchase = table.Column<DateTime>(nullable: false),
                    YearProduction = table.Column<DateTime>(nullable: false),
                    ImageCar = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
