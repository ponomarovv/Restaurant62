using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class pricelist3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PricelisTasdfasdfasdfId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_PricelisTasdfasdfasdfId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "PricelisTasdfasdfasdfId",
                table: "Dishes");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_PriceListId",
                table: "Dishes",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PriceListId",
                table: "Dishes",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PriceListId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_PriceListId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "PricelisTasdfasdfasdfId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_PricelisTasdfasdfasdfId",
                table: "Dishes",
                column: "PricelisTasdfasdfasdfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PricelisTasdfasdfasdfId",
                table: "Dishes",
                column: "PricelisTasdfasdfasdfId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
