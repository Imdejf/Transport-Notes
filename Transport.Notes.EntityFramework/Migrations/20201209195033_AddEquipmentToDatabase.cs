using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transport.Notes.EntityFramework.Migrations
{
    public partial class AddEquipmentToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateGive = table.Column<DateTime>(nullable: false),
                    VehicleEquipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Vehicles_VehicleEquipmentId",
                        column: x => x.VehicleEquipmentId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_VehicleEquipmentId",
                table: "Equipments",
                column: "VehicleEquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
