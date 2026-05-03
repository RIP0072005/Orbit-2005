using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColumnToOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cosing",
                table: "Order",
                newName: "Costing");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Costing",
                table: "Order",
                newName: "Cosing");
        }
    }
}
