using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Transport.Notes.EntityFramework.Migrations
{
    public partial class AddEquipmentToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateGive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EquipmentId",
                table: "Vehicles",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Equipments_EquipmentId",
                table: "Vehicles",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Equipments_EquipmentId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EquipmentId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Vehicles");
        }
    }
}
