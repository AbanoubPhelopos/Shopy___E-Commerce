using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageURLIntoProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "products");
        }
    }
}
