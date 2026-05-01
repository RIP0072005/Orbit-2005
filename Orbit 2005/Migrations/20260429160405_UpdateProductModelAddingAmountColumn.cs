using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orbit_2005.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductModelAddingAmountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Product");
        }
    }
}
