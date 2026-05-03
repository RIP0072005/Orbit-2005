using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class SetValuesToNullWhenDeletingPlanet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Planet_planetId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Planet_planetId",
                table: "Product",
                column: "planetId",
                principalTable: "Planet",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User",
                column: "PlanetId",
                principalTable: "Planet",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Planet_planetId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Planet_planetId",
                table: "Product",
                column: "planetId",
                principalTable: "Planet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Planet_PlanetId",
                table: "User",
                column: "PlanetId",
                principalTable: "Planet",
                principalColumn: "Id");
        }
    }
}
