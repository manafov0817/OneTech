using Microsoft.EntityFrameworkCore.Migrations;

namespace OneTech.Data.Migrations
{
    public partial class RelateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relate",
                columns: table => new
                {
                    RelateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relate", x => x.RelateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRelates_RelateId",
                table: "ProductRelates",
                column: "RelateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRelates_Relate_RelateId",
                table: "ProductRelates",
                column: "RelateId",
                principalTable: "Relate",
                principalColumn: "RelateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRelates_Relate_RelateId",
                table: "ProductRelates");

            migrationBuilder.DropTable(
                name: "Relate");

            migrationBuilder.DropIndex(
                name: "IX_ProductRelates_RelateId",
                table: "ProductRelates");
        }
    }
}
