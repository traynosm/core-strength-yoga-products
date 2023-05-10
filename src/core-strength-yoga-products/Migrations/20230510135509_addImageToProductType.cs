using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_strength_yoga_products.Migrations
{
    /// <inheritdoc />
    public partial class addImageToProductType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ProductType",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "~/images/banner-1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ImageId",
                table: "ProductType",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Image_ImageId",
                table: "ProductType",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Image_ImageId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ImageId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductType");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "");
        }
    }
}
