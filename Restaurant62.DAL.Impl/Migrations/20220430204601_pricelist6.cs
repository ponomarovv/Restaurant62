using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class pricelist6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "PricelistId",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes",
                column: "PricelistId",
                principalTable: "PriceLists",
                principalColumn: "PricelistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "PricelistId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_PriceLists_PricelistId",
                table: "Dishes",
                column: "PricelistId",
                principalTable: "PriceLists",
                principalColumn: "PricelistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
