using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "PlanetId",
                table: "User",
                newName: "planetId");

            migrationBuilder.RenameIndex(
                name: "IX_User_PlanetId",
                table: "User",
                newName: "IX_User_planetId");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Planet_planetId",
                table: "User",
                column: "planetId",
                principalTable: "Planet",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Planet_planetId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "planetId",
                table: "User",
                newName: "PlanetId");

            migrationBuilder.RenameIndex(
                name: "IX_User_planetId",
                table: "User",
                newName: "IX_User_PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User",
                column: "PlanetId",
                principalTable: "Planet",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
