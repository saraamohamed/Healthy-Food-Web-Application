using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyFoodWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ProductEditv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Product",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Product",
                newName: "Type");
        }
    }
}
