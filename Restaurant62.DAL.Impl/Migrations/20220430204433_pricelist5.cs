using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant62.DAL.Impl.Migrations
{
    public partial class pricelist5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PriceLists",
                newName: "PricelistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricelistId",
                table: "PriceLists",
                newName: "Id");
        }
    }
}
