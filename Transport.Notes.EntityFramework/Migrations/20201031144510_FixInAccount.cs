using Microsoft.EntityFrameworkCore.Migrations;

namespace Transport.Notes.EntityFramework.Migrations
{
    public partial class FixInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "carBrand",
                table: "Vehicles",
                newName: "CarBrand");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AccountId",
                table: "Vehicles",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AccountId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CarBrand",
                table: "Vehicles",
                newName: "carBrand");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
