using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core_strength_yoga_products.Migrations
{
    /// <inheritdoc />
    public partial class DomainModel_withattributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColourName = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenderName = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SizeName = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ColourId",
                table: "ProductAttributes",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_GenderId",
                table: "ProductAttributes",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_SizeId",
                table: "ProductAttributes",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Colour_ColourId",
                table: "ProductAttributes",
                column: "ColourId",
                principalTable: "Colour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Gender_GenderId",
                table: "ProductAttributes",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Size_SizeId",
                table: "ProductAttributes",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Colour_ColourId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Gender_GenderId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Size_SizeId",
                table: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_ColourId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_GenderId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_SizeId",
                table: "ProductAttributes");
        }
    }
}
