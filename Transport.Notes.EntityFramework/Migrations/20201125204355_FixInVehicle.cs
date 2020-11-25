using Microsoft.EntityFrameworkCore.Migrations;

namespace Transport.Notes.EntityFramework.Migrations
{
    public partial class FixInVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnigneNumber",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "EnigneNumber",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
