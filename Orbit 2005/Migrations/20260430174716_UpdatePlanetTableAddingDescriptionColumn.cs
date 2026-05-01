using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlanetTableAddingDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Planet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Planet");
        }
    }
}
