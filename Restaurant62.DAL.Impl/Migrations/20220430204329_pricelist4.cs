using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class pricelist4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PriceListId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "PriceListId",
                table: "Dishes",
                newName: "PricelistId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_PriceListId",
                table: "Dishes",
                newName: "IX_Dishes_PricelistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes",
                column: "PricelistId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "PricelistId",
                table: "Dishes",
                newName: "PriceListId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_PricelistId",
                table: "Dishes",
                newName: "IX_Dishes_PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PriceListId",
                table: "Dishes",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
