using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace core_strength_yoga_products.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Description", "ProductCategoryName" },
                values: new object[] { 1, "Our Selection of Mats", "Mats" });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Description", "ProductTypeName" },
                values: new object[,]
                {
                    { 1, "Our Selection of Equipment", "Equipment" },
                    { 2, "Our Selection of Clothing", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "FullPrice", "Name", "ProductCategoryId", "ProductTypeId" },
                values: new object[] { 1, "The worst yoga mat you have ever seen", 30m, "Bog Standard Yoga Mat", 1, 1 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "Alt", "ImageName", "Path", "ProductId" },
                values: new object[] { 1, "some alt", "yoga-mat-1", "", 1 });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Colour", "Gender", "PriceAdjustment", "ProductId", "Size", "StockLevel" },
                values: new object[] { 1, 2, 1, 0m, 1, 3, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
