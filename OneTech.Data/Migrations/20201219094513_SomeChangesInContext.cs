using Microsoft.EntityFrameworkCore.Migrations;

namespace OneTech.Data.Migrations
{
    public partial class SomeChangesInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMainCategory_MainCategories_MainCategoryId",
                table: "ProductMainCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMainCategory_Products_ProductId",
                table: "ProductMainCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMainCategory",
                table: "ProductMainCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductMainCategory",
                newName: "ProductMainCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMainCategory_MainCategoryId",
                table: "ProductMainCategories",
                newName: "IX_ProductMainCategories_MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMainCategories",
                table: "ProductMainCategories",
                columns: new[] { "ProductId", "MainCategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMainCategories_MainCategories_MainCategoryId",
                table: "ProductMainCategories",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMainCategories_Products_ProductId",
                table: "ProductMainCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMainCategories_MainCategories_MainCategoryId",
                table: "ProductMainCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMainCategories_Products_ProductId",
                table: "ProductMainCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMainCategories",
                table: "ProductMainCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductMainCategories",
                newName: "ProductMainCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMainCategories_MainCategoryId",
                table: "ProductMainCategory",
                newName: "IX_ProductMainCategory_MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMainCategory",
                table: "ProductMainCategory",
                columns: new[] { "ProductId", "MainCategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMainCategory_MainCategories_MainCategoryId",
                table: "ProductMainCategory",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMainCategory_Products_ProductId",
                table: "ProductMainCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
