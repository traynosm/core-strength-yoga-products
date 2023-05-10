using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace core_strength_yoga_products.Migrations
{
    /// <inheritdoc />
    public partial class updateForeignKeysProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
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

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductAttributes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Image",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductAttributes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Image",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Colour", "Gender", "PriceAdjustment", "ProductId", "Size", "StockLevel" },
                values: new object[] { 1, 2, 1, 0m, null, 3, 10 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
