using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_strength_yoga_products.Migrations
{
    /// <inheritdoc />
    public partial class addImageToProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ProductCategory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ImageId",
                table: "ProductCategory",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Image_ImageId",
                table: "ProductCategory",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Image_ImageId",
                table: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategory_ImageId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductCategory");
        }
    }
}
