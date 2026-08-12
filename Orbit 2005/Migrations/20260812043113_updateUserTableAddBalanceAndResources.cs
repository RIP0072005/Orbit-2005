using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTableAddBalanceAndResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "User",
                newName: "GalacticCredits");

            migrationBuilder.AddColumn<int>(
                name: "DarkMatter",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlasmaCores",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Titanium",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DarkMatter",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlasmaCores",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Titanium",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "GalacticCredits",
                table: "User",
                newName: "Balance");
        }
    }
}
