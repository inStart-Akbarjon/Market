using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexingForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Id_Price",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_DeletedAt",
                table: "Products",
                columns: new[] { "Id", "DeletedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Id_DeletedAt",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_Price",
                table: "Products",
                columns: new[] { "Id", "Price" });
        }
    }
}
